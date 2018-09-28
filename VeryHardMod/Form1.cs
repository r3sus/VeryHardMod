using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using MeowDSIO;
using MeowDSIO.DataFiles;
using MeowDSIO.DataTypes;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace VeryHardMod
{
    public partial class Form1 : Form
    {
        string gameDirectory = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //check if running exe from data directory
            gameDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            gameDirectory = @"D:\Program Files (x86)\Steam\steamapps\common\Dark Souls Prepare to Die Edition\DATA\";

            if (File.Exists(gameDirectory + "\\DARKSOULS.exe"))
            {
                //exe is in a valid game directory, just use this as the path instead of asking for input
                txtGamePath.Text = gameDirectory;
                txtGamePath.ReadOnly = true;

                if (!File.Exists(gameDirectory + "\\param\\GameParam\\GameParam.parambnd"))
                {
                    //user hasn't unpacked their game
                    lblMessage.Text = "You don't seem to have an unpacked Dark Souls installation. Please run UDSFM and come back :)";
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }

        private void btnOpenFolderDialog_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtGamePath.Text = dialog.FileName;
                gameDirectory = dialog.FileName;

                lblMessage.Text = "";
                lblMessage.Visible = true;

                if (!File.Exists(gameDirectory + "\\DARKSOULS.exe"))
                {
                    lblMessage.Text = "Not a valid Data directory!";
                    lblMessage.ForeColor = Color.Red;
                    return;
                }
                else if (!File.Exists(gameDirectory + "\\param\\GameParam\\GameParam.parambnd"))
                {
                    //user hasn't unpacked their game
                    lblMessage.Text = "You don't seem to have an unpacked Dark Souls installation. Please run UDSFM and come back :)";
                    lblMessage.ForeColor = Color.Red;
                    return;
                }
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            //check that entered path is valid
            gameDirectory = txtGamePath.Text;

            //reset message label
            lblMessage.Text = "";
            lblMessage.ForeColor = new Color();
            lblMessage.Visible = true;

            if (!File.Exists(gameDirectory + "\\DARKSOULS.exe"))
            {
                lblMessage.Text = "Not a valid Data directory!";
                lblMessage.ForeColor = Color.Red;
                return;
            }
            else if (!File.Exists(gameDirectory + "\\param\\GameParam\\GameParam.parambnd"))
            {
                //user hasn't unpacked their game
                lblMessage.Text = "You don't seem to have an unpacked Dark Souls installation. Please run UDSFM and come back :)";
                lblMessage.ForeColor = Color.Red;
                return;
            }

            //update label on a new thread
            Progress<string> progress = new Progress<string>(s => lblMessage.Text = s);
            await Task.Factory.StartNew(() => UiThread.WriteToInfoLabel(progress));


            //TODO backup map files
            //create backup of gameparam
            if (!File.Exists(gameDirectory + "\\param\\GameParam\\GameParam.parambnd.bak"))
            {
                File.Copy(gameDirectory + "\\param\\GameParam\\GameParam.parambnd", gameDirectory + "\\param\\GameParam\\GameParam.parambnd.bak");
                lblMessage.Text = "Backed up GameParam.parambnd \n\n";
                lblMessage.ForeColor = Color.Black;
                lblMessage.Visible = true;
            }

            List<PARAMDEF> ParamDefs = new List<PARAMDEF>();
            List<PARAM> AllParams = new List<PARAM>();

            List<BND> gameparamBnds = Directory.GetFiles(gameDirectory + "\\param\\GameParam\\", "*.parambnd")
                .Select(p => DataFile.LoadFromFile<BND>(p, new Progress<(int, int)> ((pr) =>
                {

                }))).ToList();

            List<BND> paramdefBnds = Directory.GetFiles(gameDirectory + "\\paramdef\\", "*.paramdefbnd")
                .Select(p => DataFile.LoadFromFile<BND>(p, new Progress<(int, int)> ((pr) =>
                {

                }))).ToList();

            for (int i = 0; i < paramdefBnds.Count(); i++)
            {
                foreach (MeowDSIO.DataTypes.BND.BNDEntry paramdef in paramdefBnds[i])
                {
                    PARAMDEF newParamDef = paramdef.ReadDataAs<PARAMDEF>(new Progress<(int, int)> ((p) =>
                    {

                    }));
                    ParamDefs.Add(newParamDef);
                }
            }

            for (int i = 0; i < gameparamBnds.Count(); i++)
            {
                foreach (MeowDSIO.DataTypes.BND.BNDEntry param in gameparamBnds[i])
                {
                    PARAM newParam = param.ReadDataAs<PARAM>(new Progress<(int, int)> ((p) =>
                    {

                    }));

                    newParam.ApplyPARAMDEFTemplate(ParamDefs.Where(x => x.ID == newParam.ID).First());
                    AllParams.Add(newParam);
                }
            }

            foreach (PARAM paramFile in AllParams)
            {
                //ID is same between PC and NPC atk params - use virtual uri to differentiate
                if (paramFile.VirtualUri.EndsWith("AtkParam_Npc.param"))
                {
                    foreach (MeowDSIO.DataTypes.PARAM.ParamRow paramRow in paramFile.Entries)
                    {
                        foreach (MeowDSIO.DataTypes.PARAM.ParamCellValueRef cell in paramRow.Cells)
                        {
                            if (cell.Def.Name == "knockbackDist" && chkKnockback.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                //TODO check if this value is good
                                prop.SetValue(cell, (float)(prop.GetValue(cell, null)) * 5, null);
                            }
                            else if (cell.Def.Name == "dmgLevel" && chkKnockDown.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                prop.SetValue(cell, 7, null);
                            }
                            else if (cell.Def.Name.EndsWith("_Radius") && chkLargerHitboxes.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                //TODO tweak this
                                prop.SetValue(cell, (float)(prop.GetValue(cell, null)) * 1.1, null);
                            }
                            else if (cell.Def.Name == "atkSuperArmor" && chkAttackSuperArmor.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                if (Convert.ToInt32(prop.GetValue(cell, null)) < 100)
                                {
                                    prop.SetValue(cell, 100, null);
                                }
                            }
                            else if (cell.Def.Name == "DisableGuard" && chkAttackThroughGuard.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                prop.SetValue(cell, 1, null);
                            }
                        }
                    }
                }
                else if (paramFile.VirtualUri.EndsWith("AtkParam_Pc.param"))
                {
                    foreach (MeowDSIO.DataTypes.PARAM.ParamRow paramRow in paramFile.Entries)
                    {
                        foreach (MeowDSIO.DataTypes.PARAM.ParamCellValueRef cell in paramRow.Cells)
                        {
                            if(cell.Def.Name.EndsWith("_hitType") && chkWeaponSourSpot.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                prop.SetValue(cell, 2, null);
                            }
                        }
                    }
                }
                else if (paramFile.ID == "EQUIP_PARAM_ACCESSORY_ST")
                {
                    foreach (MeowDSIO.DataTypes.PARAM.ParamRow paramRow in paramFile.Entries)
                    {
                        foreach (MeowDSIO.DataTypes.PARAM.ParamCellValueRef cell in paramRow.Cells)
                        {
                            if (cell.Def.Name == "isEquipOutBrake:1" && chkRingsBreak.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                prop.SetValue(cell, true, null);
                            }
                        }
                    }
                }
                else if (paramFile.ID == "EQUIP_MTRL_SET_PARAM_ST")
                {
                    foreach (MeowDSIO.DataTypes.PARAM.ParamRow paramRow in paramFile.Entries)
                    {
                        foreach (MeowDSIO.DataTypes.PARAM.ParamCellValueRef cell in paramRow.Cells)
                        {
                            if (cell.Def.Name.StartsWith("itemNum") && chkUpgradeCost.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                prop.SetValue(cell, Convert.ToInt32(prop.GetValue(cell, null))+1, null);
                            }
                        }
                    }
                }
                else if (paramFile.ID == "EQUIP_PARAM_WEAPON_ST")
                {
                    foreach (MeowDSIO.DataTypes.PARAM.ParamRow paramRow in paramFile.Entries)
                    {
                        foreach (MeowDSIO.DataTypes.PARAM.ParamCellValueRef cell in paramRow.Cells)
                        {
                            if ((cell.Def.Name == "durability" || cell.Def.Name == "durabilityMax") && chkWeaponBreak.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                double temp = Convert.ToDouble(prop.GetValue(cell, null));
                                int newDurability = Convert.ToInt32(Math.Floor(temp) / 10);

                                prop.SetValue(cell, newDurability, null);
                            }
                            else if (cell.Def.Name == "disableRepair:1" && chkWeaponBreak.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                prop.SetValue(cell, true, null);
                            }
                        }
                    }
                }
                else if (paramFile.ID == "NPC_PARAM_ST")
                {
                    //loop again to set a random value per entry
                    foreach (MeowDSIO.DataTypes.PARAM.ParamRow paramRow in paramFile.Entries)
                    {
                        foreach (MeowDSIO.DataTypes.PARAM.ParamCellValueRef cell in paramRow.Cells)
                        {
                            //max turn velocity cuz its hilarous and OP
                            if (cell.Def.Name == "turnVellocity" && chkTurnSpeed.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                prop.SetValue(cell, cell.Def.Max, null);
                            }
                            else if((cell.Def.Name == "stamina" || cell.Def.Name == "staminaRecoverBaseVal") && chkStaminaRegen.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                prop.SetValue(cell, cell.Def.Max, null);
                            }
                            else if(cell.Def.Name == "teamType" && chkNPCAggro.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                int teamType = Convert.ToInt32(prop.GetValue(cell, null));
                                //friendly or summon (yes summons will attack you)
                                if (teamType == 2 || teamType == 7)
                                {
                                    prop.SetValue(cell, 0, null);
                                }
                            }
                            else if (cell.Def.Name == "moveType" && chkFlyingEnemies.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                //TODO try changing this to other numbers
                                prop.SetValue(cell, 6, null);
                            }
                        }
                    }
                }
                else if (paramFile.ID == "NPC_THINK_PARAM_ST")
                {
                    foreach (MeowDSIO.DataTypes.PARAM.ParamRow paramRow in paramFile.Entries)
                    {
                        foreach (MeowDSIO.DataTypes.PARAM.ParamCellValueRef cell in paramRow.Cells)
                        {
                            if (chkAggroMod.Checked)
                            {
                                string[] attrsToMax = { "farDist", "outDist", "eye_dist", "ear_dist", "nose_dist", "maxBackhomeDist", "backhomeDist", "backhomeBattleDist", "BackHome_LookTargetTime", "BackHome_LookTargetDist", "BattleStartDist", "eye_angX", "eye_angY", "ear_angX", "ear_angY", "SightTargetForgetTime", "SoundTargetForgetTime" };
                                if (attrsToMax.Contains(cell.Def.Name))
                                {
                                    Type type = cell.GetType();
                                    PropertyInfo prop = type.GetProperty("Value");
                                    prop.SetValue(cell, cell.Def.Max, null);
                                }

                                string[] attrsToMin = { "nearDist", "midDist" };
                                if (attrsToMin.Contains(cell.Def.Name))
                                {
                                    Type type = cell.GetType();
                                    PropertyInfo prop = type.GetProperty("Value");
                                    prop.SetValue(cell, cell.Def.Min, null);
                                }
                                else if (cell.Def.Name == "CallHelp_ReplyBehaviorType")
                                {
                                    Type type = cell.GetType();
                                    PropertyInfo prop = type.GetProperty("Value");
                                    prop.SetValue(cell, 1, null);
                                }
                                else if (cell.Def.Name == "CallHelp_ActionAnimId")
                                {
                                    Type type = cell.GetType();
                                    PropertyInfo prop = type.GetProperty("Value");
                                    prop.SetValue(cell, -1, null);
                                }
                                else if (cell.Def.Name == "CallHelp_ForgetTimeByArrival")
                                {
                                    Type type = cell.GetType();
                                    PropertyInfo prop = type.GetProperty("Value");
                                    prop.SetValue(cell, 20, null);
                                }
                                else if (cell.Def.Name == "CallHelp_CallValidRange")
                                {
                                    Type type = cell.GetType();
                                    PropertyInfo prop = type.GetProperty("Value");
                                    prop.SetValue(cell, 50, null);
                                }
                                else if (cell.Def.Name == "CallHelp_MinWaitTime")
                                {
                                    Type type = cell.GetType();
                                    PropertyInfo prop = type.GetProperty("Value");
                                    prop.SetValue(cell, 0, null);
                                }
                                else if (cell.Def.Name == "CallHelp_MaxWaitTime")
                                {
                                    Type type = cell.GetType();
                                    PropertyInfo prop = type.GetProperty("Value");
                                    prop.SetValue(cell, 10, null);
                                }
                            }
                        }
                    }
                }
                else if (paramFile.ID == "CHARACTER_INIT_PARAM")
                {
                    foreach (MeowDSIO.DataTypes.PARAM.ParamRow paramRow in paramFile.Entries)
                    {
                        foreach (MeowDSIO.DataTypes.PARAM.ParamCellValueRef cell in paramRow.Cells)
                        {
                            if(cell.Def.Name == "baseVit" && chkSwoleInvaders.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                prop.SetValue(cell, Convert.ToInt32(prop.GetValue(cell, null)) * 1.5, null);
                            }
                            else if(cell.Def.Name == "baseEnd" && chkSwoleInvaders.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                prop.SetValue(cell, Convert.ToInt32(prop.GetValue(cell, null)) * 1.5, null);
                            }
                            else if (cell.Def.Name == "baseStr" && chkSwoleInvaders.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                prop.SetValue(cell, Convert.ToInt32(prop.GetValue(cell, null)) * 1.5, null);
                            }
                            else if (cell.Def.Name == "baseDex" && chkSwoleInvaders.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                prop.SetValue(cell, Convert.ToInt32(prop.GetValue(cell, null)) * 1.5, null);
                            }
                            else if (cell.Def.Name == "bodyScaleHead" && chkSwoleInvaders.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                prop.SetValue(cell, 10, null);
                            }
                            else if (cell.Def.Name == "bodyScaleBreast" && chkSwoleInvaders.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                prop.SetValue(cell, 50, null);
                            }
                            else if (cell.Def.Name == "bodyScaleAbdomen" && chkSwoleInvaders.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                prop.SetValue(cell, 10, null);
                            }
                            else if (cell.Def.Name == "bodyScaleArm" && chkSwoleInvaders.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                prop.SetValue(cell, 100, null);
                            }
                            else if (cell.Def.Name == "bodyScaleLeg" && chkSwoleInvaders.Checked)
                            {
                                Type type = cell.GetType();
                                PropertyInfo prop = type.GetProperty("Value");
                                prop.SetValue(cell, 50, null);
                            }
                        }
                    }
                }
                else if (paramFile.ID == "BULLET_PARAM_ST")
                {                    
                    foreach (MeowDSIO.DataTypes.PARAM.ParamRow paramRow in paramFile.Entries)
                    {
                        foreach (MeowDSIO.DataTypes.PARAM.ParamCellValueRef cell in paramRow.Cells)
                        {                          
                            if(cell.Def.Name == "HomingAngle" && chkHomingBullets.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                prop.SetValue(cell, (float)(prop.GetValue(cell, null)) + 45, null);
                            }
                            else if(cell.Def.Name == "homingBeginDist" && chkHomingBullets.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                prop.SetValue(cell, (float)10, null);
                            }
                            else if (cell.Def.Name == "hormingStopRange" && chkHomingBullets.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                prop.SetValue(cell, (float)0, null);
                            }
                            else if(cell.Def.Name == "maxVellocity" && chkFasterBullets.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                prop.SetValue(cell, (float)(prop.GetValue(cell, null)) * 2, null);
                            }
                            else if(cell.Def.Name == "initVellocity" && chkFasterBullets.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                prop.SetValue(cell, (float)(prop.GetValue(cell, null)) * 2, null);
                            }
                            else if (cell.Def.Name == "minVellocity" && chkFasterBullets.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                prop.SetValue(cell, (float)(prop.GetValue(cell, null)) * 2, null);
                            }
                            else if (cell.Def.Name == "numShoot" && chKMoreBullets.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                prop.SetValue(cell, Convert.ToInt32(prop.GetValue(cell, null)) + 5, null);
                            }
                            else if (cell.Def.Name == "spreadTime" && chKMoreBullets.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                prop.SetValue(cell, Convert.ToInt32(prop.GetValue(cell, null)) + 2, null);
                            }
                            else if (cell.Def.Name == "shootAngleInterval" && chKMoreBullets.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                prop.SetValue(cell, Convert.ToInt32(prop.GetValue(cell, null)) + 5, null);
                            }
                            //else if (cell.Def.Name == "shootAngle" && chKMoreBullets.Checked)
                            //{
                            //    PropertyInfo prop = cell.GetType().GetProperty("Value");
                            //    prop.SetValue(cell, Convert.ToInt32(prop.GetValue(cell, null)) + 5, null);
                            //}
                            //else if (cell.Def.Name == "shootAngleXInterval" && chKMoreBullets.Checked)
                            //{
                            //    PropertyInfo prop = cell.GetType().GetProperty("Value");
                            //    prop.SetValue(cell, Convert.ToInt32(prop.GetValue(cell, null)) + 5, null);
                            //}
                            else if (cell.Def.Name == "isPenetrateMap:1" && chkBulletsPentrateMap.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                prop.SetValue(cell, true, null);
                            }
                            else if (cell.Def.Name == "isEndlessHit:1" && chkBulletEndlessHit.Checked)
                            {
                                PropertyInfo prop = cell.GetType().GetProperty("Value");
                                prop.SetValue(cell, true, null);
                            }
                        }
                    }
                }
            }

            foreach (BND paramBnd in gameparamBnds)
            {
                foreach (MeowDSIO.DataTypes.BND.BNDEntry param in paramBnd)
                {
                    string filteredParamName = param.Name.Substring(param.Name.LastIndexOf("\\") + 1).Replace(".param", "");

                    PARAM matchingParam = AllParams.Where(x => x.VirtualUri == param.Name).First();

                    param.ReplaceData(matchingParam,
                        new Progress<(int, int)> ((p) =>
                        {

                        }));
                }

                DataFile.Resave(paramBnd, new Progress<(int, int)> ((p) =>
                {

                }));
            }

            if (chkGravelorded.Checked) {
                //load msbs
                List<MSB> msbs = Directory.GetFiles(gameDirectory + "\\map\\MapStudio\\", "*.msb")
                    .Select(p => DataFile.LoadFromFile<MSB>(p, new Progress<(int, int) > ((pr) =>
                    {

                    }))).ToList();

                int[] gravelordParamIds = { 120104, 206003, 206004, 206005, 224002, 227002, 228002, 237003, 238002, 239003, 241005, 241006, 250032, 250033, 250053, 252001, 254013, 254014, 255043, 255044, 256003, 256004, 256013, 256014, 257002, 257012, 257022, 266001, 269004, 270002, 271002, 279060, 279061, 279062, 279063, 281001, 281101, 284003, 284004, 287001, 287011, 290013, 290014, 291015, 293002, 293003, 295001, 324001, 333003, 349050, 349051, 349052, 349053, 349054, 349055, 349056, 349057, 349058, 349059, 349060, 349061, 349062, 349063, 349064, 349200, 349201, 349202, 349203, 349204, 349205, 349206, 349207, 349208, 349209, 349210, 349211, 349212, 349213, 349214, 409010, 412001, 413004, 413014, 415001, 416001, 418001 };


                //disassociate gravelord npcs with their events, since they default to enabled
                foreach (MSB map in msbs)
                {
                    foreach (var NPC in map.Parts.NPCs)
                    {
                        if (gravelordParamIds.Contains(NPC.NPCParamID))
                        {
                            NPC.EventEntityID = -1;
                        }
                    }
                }

                //resave MSB
                foreach (MSB map in msbs)
                {
                    DataFile.Resave(map, new Progress<(int, int) > ((p) =>
                    {

                    }));
                }
            }

            if (rdbInsultingHitSounds1.Checked)
            {
                File.WriteAllBytes(gameDirectory + "\\sound\\frpg_main.fsb", Resources.hitSounds1);

            }
            else if (rdbInsultingHitSounds2.Checked)
            {
                File.WriteAllBytes(gameDirectory + "\\sound\\frpg_main.fsb", Resources.hitSounds2);
            }

            lblMessage.Text += "Modifying Complete!";
            lblMessage.ForeColor = Color.Black;
            lblMessage.Visible = true;
        }

        public class UiThread
        {
            public static void WriteToInfoLabel(IProgress<string> progress)
            {
                //why is this necessary
                //without the loop it doesnt run async
                for (var i = 0; i < 5; i++)
                {
                    Task.Delay(10).Wait();
                    progress.Report("Randomizing...\n\n");
                }
            }
        }

    }
}
