namespace VeryHardMod
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblGamePath = new System.Windows.Forms.Label();
            this.txtGamePath = new System.Windows.Forms.TextBox();
            this.chkKnockback = new System.Windows.Forms.CheckBox();
            this.chkFasterBullets = new System.Windows.Forms.CheckBox();
            this.chkHomingBullets = new System.Windows.Forms.CheckBox();
            this.chkStaminaRegen = new System.Windows.Forms.CheckBox();
            this.chkTurnSpeed = new System.Windows.Forms.CheckBox();
            this.chkLargerHitboxes = new System.Windows.Forms.CheckBox();
            this.chkKnockDown = new System.Windows.Forms.CheckBox();
            this.chkAggroMod = new System.Windows.Forms.CheckBox();
            this.chkGravelorded = new System.Windows.Forms.CheckBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tooltip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnOpenFolderDialog = new System.Windows.Forms.Button();
            this.chKMoreBullets = new System.Windows.Forms.CheckBox();
            this.chkRingsBreak = new System.Windows.Forms.CheckBox();
            this.chkWeaponBreak = new System.Windows.Forms.CheckBox();
            this.chkNPCAggro = new System.Windows.Forms.CheckBox();
            this.chkAttackSuperArmor = new System.Windows.Forms.CheckBox();
            this.chkAttackThroughGuard = new System.Windows.Forms.CheckBox();
            this.chkWeaponSourSpot = new System.Windows.Forms.CheckBox();
            this.chkUpgradeCost = new System.Windows.Forms.CheckBox();
            this.chkBulletEndlessHit = new System.Windows.Forms.CheckBox();
            this.chkBulletsPentrateMap = new System.Windows.Forms.CheckBox();
            this.chkSwoleInvaders = new System.Windows.Forms.CheckBox();
            this.chkFlyingEnemies = new System.Windows.Forms.CheckBox();
            this.rdbInsultingHitSounds1 = new System.Windows.Forms.RadioButton();
            this.rdbInsultingHitSounds2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblGamePath
            // 
            this.lblGamePath.AutoSize = true;
            this.lblGamePath.Location = new System.Drawing.Point(8, 9);
            this.lblGamePath.Name = "lblGamePath";
            this.lblGamePath.Size = new System.Drawing.Size(63, 13);
            this.lblGamePath.TabIndex = 2;
            this.lblGamePath.Text = "Game Path:";
            // 
            // txtGamePath
            // 
            this.txtGamePath.Location = new System.Drawing.Point(77, 6);
            this.txtGamePath.Name = "txtGamePath";
            this.txtGamePath.Size = new System.Drawing.Size(346, 20);
            this.txtGamePath.TabIndex = 0;
            this.tooltip1.SetToolTip(this.txtGamePath, "Point to the DATA directory");
            // 
            // chkKnockback
            // 
            this.chkKnockback.AutoSize = true;
            this.chkKnockback.Checked = true;
            this.chkKnockback.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKnockback.Location = new System.Drawing.Point(35, 213);
            this.chkKnockback.Name = "chkKnockback";
            this.chkKnockback.Size = new System.Drawing.Size(217, 17);
            this.chkKnockback.TabIndex = 3;
            this.chkKnockback.Text = "Increased knockback on enemy attacks";
            this.chkKnockback.UseVisualStyleBackColor = true;
            // 
            // chkFasterBullets
            // 
            this.chkFasterBullets.AutoSize = true;
            this.chkFasterBullets.Checked = true;
            this.chkFasterBullets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFasterBullets.Location = new System.Drawing.Point(272, 70);
            this.chkFasterBullets.Name = "chkFasterBullets";
            this.chkFasterBullets.Size = new System.Drawing.Size(88, 17);
            this.chkFasterBullets.TabIndex = 7;
            this.chkFasterBullets.Text = "Faster bullets";
            this.chkFasterBullets.UseVisualStyleBackColor = true;
            // 
            // chkHomingBullets
            // 
            this.chkHomingBullets.AutoSize = true;
            this.chkHomingBullets.Checked = true;
            this.chkHomingBullets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHomingBullets.Location = new System.Drawing.Point(272, 47);
            this.chkHomingBullets.Name = "chkHomingBullets";
            this.chkHomingBullets.Size = new System.Drawing.Size(134, 17);
            this.chkHomingBullets.TabIndex = 6;
            this.chkHomingBullets.Text = "All bullets have homing";
            this.chkHomingBullets.UseVisualStyleBackColor = true;
            // 
            // chkStaminaRegen
            // 
            this.chkStaminaRegen.AutoSize = true;
            this.chkStaminaRegen.Checked = true;
            this.chkStaminaRegen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStaminaRegen.Location = new System.Drawing.Point(35, 166);
            this.chkStaminaRegen.Name = "chkStaminaRegen";
            this.chkStaminaRegen.Size = new System.Drawing.Size(158, 17);
            this.chkStaminaRegen.TabIndex = 5;
            this.chkStaminaRegen.Text = "Faster enemy stamina regen";
            this.chkStaminaRegen.UseVisualStyleBackColor = true;
            // 
            // chkTurnSpeed
            // 
            this.chkTurnSpeed.AutoSize = true;
            this.chkTurnSpeed.Checked = true;
            this.chkTurnSpeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTurnSpeed.Location = new System.Drawing.Point(35, 142);
            this.chkTurnSpeed.Name = "chkTurnSpeed";
            this.chkTurnSpeed.Size = new System.Drawing.Size(142, 17);
            this.chkTurnSpeed.TabIndex = 4;
            this.chkTurnSpeed.Text = "Faster enemy turn speed";
            this.chkTurnSpeed.UseVisualStyleBackColor = true;
            // 
            // chkLargerHitboxes
            // 
            this.chkLargerHitboxes.AutoSize = true;
            this.chkLargerHitboxes.Checked = true;
            this.chkLargerHitboxes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLargerHitboxes.Location = new System.Drawing.Point(35, 118);
            this.chkLargerHitboxes.Name = "chkLargerHitboxes";
            this.chkLargerHitboxes.Size = new System.Drawing.Size(185, 17);
            this.chkLargerHitboxes.TabIndex = 3;
            this.chkLargerHitboxes.Text = "Larger hitboxes on enemy attacks";
            this.chkLargerHitboxes.UseVisualStyleBackColor = true;
            // 
            // chkKnockDown
            // 
            this.chkKnockDown.AutoSize = true;
            this.chkKnockDown.Checked = true;
            this.chkKnockDown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKnockDown.Location = new System.Drawing.Point(35, 94);
            this.chkKnockDown.Name = "chkKnockDown";
            this.chkKnockDown.Size = new System.Drawing.Size(138, 17);
            this.chkKnockDown.TabIndex = 2;
            this.chkKnockDown.Text = "All hits knock you down";
            this.chkKnockDown.UseVisualStyleBackColor = true;
            // 
            // chkAggroMod
            // 
            this.chkAggroMod.AutoSize = true;
            this.chkAggroMod.Checked = true;
            this.chkAggroMod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAggroMod.Location = new System.Drawing.Point(35, 70);
            this.chkAggroMod.Name = "chkAggroMod";
            this.chkAggroMod.Size = new System.Drawing.Size(122, 17);
            this.chkAggroMod.TabIndex = 1;
            this.chkAggroMod.Text = "Aggro mod on crack";
            this.chkAggroMod.UseVisualStyleBackColor = true;
            // 
            // chkGravelorded
            // 
            this.chkGravelorded.AutoSize = true;
            this.chkGravelorded.Checked = true;
            this.chkGravelorded.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGravelorded.Location = new System.Drawing.Point(35, 47);
            this.chkGravelorded.Name = "chkGravelorded";
            this.chkGravelorded.Size = new System.Drawing.Size(117, 17);
            this.chkGravelorded.TabIndex = 0;
            this.chkGravelorded.Text = "Perma Gravelorded";
            this.chkGravelorded.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(197, 389);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Go";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // tooltip1
            // 
            this.tooltip1.AutomaticDelay = 250;
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(10, 415);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(448, 43);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "label1\r\n\r\n";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblMessage.Visible = false;
            // 
            // btnOpenFolderDialog
            // 
            this.btnOpenFolderDialog.Location = new System.Drawing.Point(429, 6);
            this.btnOpenFolderDialog.Name = "btnOpenFolderDialog";
            this.btnOpenFolderDialog.Size = new System.Drawing.Size(29, 20);
            this.btnOpenFolderDialog.TabIndex = 8;
            this.btnOpenFolderDialog.Text = "...";
            this.btnOpenFolderDialog.UseVisualStyleBackColor = true;
            this.btnOpenFolderDialog.Click += new System.EventHandler(this.btnOpenFolderDialog_Click);
            // 
            // chKMoreBullets
            // 
            this.chKMoreBullets.AutoSize = true;
            this.chKMoreBullets.Checked = true;
            this.chKMoreBullets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chKMoreBullets.Location = new System.Drawing.Point(272, 93);
            this.chKMoreBullets.Name = "chKMoreBullets";
            this.chKMoreBullets.Size = new System.Drawing.Size(86, 17);
            this.chKMoreBullets.TabIndex = 9;
            this.chKMoreBullets.Text = "More bullets!";
            this.chKMoreBullets.UseVisualStyleBackColor = true;
            // 
            // chkRingsBreak
            // 
            this.chkRingsBreak.AutoSize = true;
            this.chkRingsBreak.Checked = true;
            this.chkRingsBreak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRingsBreak.Location = new System.Drawing.Point(272, 118);
            this.chkRingsBreak.Name = "chkRingsBreak";
            this.chkRingsBreak.Size = new System.Drawing.Size(148, 17);
            this.chkRingsBreak.TabIndex = 10;
            this.chkRingsBreak.Text = "All rings break on unequip";
            this.chkRingsBreak.UseVisualStyleBackColor = true;
            // 
            // chkWeaponBreak
            // 
            this.chkWeaponBreak.AutoSize = true;
            this.chkWeaponBreak.Checked = true;
            this.chkWeaponBreak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWeaponBreak.Location = new System.Drawing.Point(272, 141);
            this.chkWeaponBreak.Name = "chkWeaponBreak";
            this.chkWeaponBreak.Size = new System.Drawing.Size(135, 17);
            this.chkWeaponBreak.TabIndex = 11;
            this.chkWeaponBreak.Text = "All weapons like crystal";
            this.chkWeaponBreak.UseVisualStyleBackColor = true;
            // 
            // chkNPCAggro
            // 
            this.chkNPCAggro.AutoSize = true;
            this.chkNPCAggro.Checked = true;
            this.chkNPCAggro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNPCAggro.Location = new System.Drawing.Point(272, 213);
            this.chkNPCAggro.Name = "chkNPCAggro";
            this.chkNPCAggro.Size = new System.Drawing.Size(120, 17);
            this.chkNPCAggro.TabIndex = 12;
            this.chkNPCAggro.Text = "Everyone hates you";
            this.chkNPCAggro.UseVisualStyleBackColor = true;
            // 
            // chkAttackSuperArmor
            // 
            this.chkAttackSuperArmor.AutoSize = true;
            this.chkAttackSuperArmor.Checked = true;
            this.chkAttackSuperArmor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAttackSuperArmor.Location = new System.Drawing.Point(35, 190);
            this.chkAttackSuperArmor.Name = "chkAttackSuperArmor";
            this.chkAttackSuperArmor.Size = new System.Drawing.Size(149, 17);
            this.chkAttackSuperArmor.TabIndex = 13;
            this.chkAttackSuperArmor.Text = "Super armor on all attacks";
            this.chkAttackSuperArmor.UseVisualStyleBackColor = true;
            // 
            // chkAttackThroughGuard
            // 
            this.chkAttackThroughGuard.AutoSize = true;
            this.chkAttackThroughGuard.Checked = true;
            this.chkAttackThroughGuard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAttackThroughGuard.Location = new System.Drawing.Point(35, 236);
            this.chkAttackThroughGuard.Name = "chkAttackThroughGuard";
            this.chkAttackThroughGuard.Size = new System.Drawing.Size(158, 17);
            this.chkAttackThroughGuard.TabIndex = 14;
            this.chkAttackThroughGuard.Text = "All attacks hit through guard";
            this.chkAttackThroughGuard.UseVisualStyleBackColor = true;
            // 
            // chkWeaponSourSpot
            // 
            this.chkWeaponSourSpot.AutoSize = true;
            this.chkWeaponSourSpot.Checked = true;
            this.chkWeaponSourSpot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWeaponSourSpot.Location = new System.Drawing.Point(272, 165);
            this.chkWeaponSourSpot.Name = "chkWeaponSourSpot";
            this.chkWeaponSourSpot.Size = new System.Drawing.Size(145, 17);
            this.chkWeaponSourSpot.TabIndex = 15;
            this.chkWeaponSourSpot.Text = "Sour spot on all weapons";
            this.chkWeaponSourSpot.UseVisualStyleBackColor = true;
            // 
            // chkUpgradeCost
            // 
            this.chkUpgradeCost.AutoSize = true;
            this.chkUpgradeCost.Checked = true;
            this.chkUpgradeCost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpgradeCost.Location = new System.Drawing.Point(272, 190);
            this.chkUpgradeCost.Name = "chkUpgradeCost";
            this.chkUpgradeCost.Size = new System.Drawing.Size(138, 17);
            this.chkUpgradeCost.TabIndex = 16;
            this.chkUpgradeCost.Text = "Increased upgrade cost";
            this.chkUpgradeCost.UseVisualStyleBackColor = true;
            // 
            // chkBulletEndlessHit
            // 
            this.chkBulletEndlessHit.AutoSize = true;
            this.chkBulletEndlessHit.Location = new System.Drawing.Point(280, 276);
            this.chkBulletEndlessHit.Name = "chkBulletEndlessHit";
            this.chkBulletEndlessHit.Size = new System.Drawing.Size(137, 17);
            this.chkBulletEndlessHit.TabIndex = 17;
            this.chkBulletEndlessHit.Text = "Bullets have endless hit";
            this.chkBulletEndlessHit.UseVisualStyleBackColor = true;
            // 
            // chkBulletsPentrateMap
            // 
            this.chkBulletsPentrateMap.AutoSize = true;
            this.chkBulletsPentrateMap.Location = new System.Drawing.Point(280, 299);
            this.chkBulletsPentrateMap.Name = "chkBulletsPentrateMap";
            this.chkBulletsPentrateMap.Size = new System.Drawing.Size(134, 17);
            this.chkBulletsPentrateMap.TabIndex = 18;
            this.chkBulletsPentrateMap.Text = "Bullets go through map";
            this.chkBulletsPentrateMap.UseVisualStyleBackColor = true;
            // 
            // chkSwoleInvaders
            // 
            this.chkSwoleInvaders.AutoSize = true;
            this.chkSwoleInvaders.Location = new System.Drawing.Point(280, 322);
            this.chkSwoleInvaders.Name = "chkSwoleInvaders";
            this.chkSwoleInvaders.Size = new System.Drawing.Size(99, 17);
            this.chkSwoleInvaders.TabIndex = 19;
            this.chkSwoleInvaders.Text = "Swole Invaders";
            this.chkSwoleInvaders.UseVisualStyleBackColor = true;
            // 
            // chkFlyingEnemies
            // 
            this.chkFlyingEnemies.AutoSize = true;
            this.chkFlyingEnemies.Location = new System.Drawing.Point(280, 346);
            this.chkFlyingEnemies.Name = "chkFlyingEnemies";
            this.chkFlyingEnemies.Size = new System.Drawing.Size(138, 17);
            this.chkFlyingEnemies.TabIndex = 20;
            this.chkFlyingEnemies.Text = "Enemies can fucking fly";
            this.chkFlyingEnemies.UseVisualStyleBackColor = true;
            // 
            // rdbInsultingHitSounds1
            // 
            this.rdbInsultingHitSounds1.AutoSize = true;
            this.rdbInsultingHitSounds1.Location = new System.Drawing.Point(23, 299);
            this.rdbInsultingHitSounds1.Name = "rdbInsultingHitSounds1";
            this.rdbInsultingHitSounds1.Size = new System.Drawing.Size(124, 17);
            this.rdbInsultingHitSounds1.TabIndex = 21;
            this.rdbInsultingHitSounds1.TabStop = true;
            this.rdbInsultingHitSounds1.Text = "Insulting hit sounds 1";
            this.rdbInsultingHitSounds1.UseVisualStyleBackColor = true;
            // 
            // rdbInsultingHitSounds2
            // 
            this.rdbInsultingHitSounds2.AutoSize = true;
            this.rdbInsultingHitSounds2.Location = new System.Drawing.Point(23, 321);
            this.rdbInsultingHitSounds2.Name = "rdbInsultingHitSounds2";
            this.rdbInsultingHitSounds2.Size = new System.Drawing.Size(124, 17);
            this.rdbInsultingHitSounds2.TabIndex = 22;
            this.rdbInsultingHitSounds2.Text = "Insulting hit sounds 2";
            this.rdbInsultingHitSounds2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rdbInsultingHitSounds2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 525);
            this.Controls.Add(this.rdbInsultingHitSounds2);
            this.Controls.Add(this.rdbInsultingHitSounds1);
            this.Controls.Add(this.chkFlyingEnemies);
            this.Controls.Add(this.chkSwoleInvaders);
            this.Controls.Add(this.chkBulletsPentrateMap);
            this.Controls.Add(this.chkBulletEndlessHit);
            this.Controls.Add(this.chkUpgradeCost);
            this.Controls.Add(this.chkWeaponSourSpot);
            this.Controls.Add(this.chkAttackThroughGuard);
            this.Controls.Add(this.chkAttackSuperArmor);
            this.Controls.Add(this.chkNPCAggro);
            this.Controls.Add(this.chkWeaponBreak);
            this.Controls.Add(this.chkRingsBreak);
            this.Controls.Add(this.chKMoreBullets);
            this.Controls.Add(this.btnOpenFolderDialog);
            this.Controls.Add(this.chkFasterBullets);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.chkHomingBullets);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.chkStaminaRegen);
            this.Controls.Add(this.chkTurnSpeed);
            this.Controls.Add(this.txtGamePath);
            this.Controls.Add(this.chkLargerHitboxes);
            this.Controls.Add(this.chkKnockback);
            this.Controls.Add(this.chkKnockDown);
            this.Controls.Add(this.lblGamePath);
            this.Controls.Add(this.chkAggroMod);
            this.Controls.Add(this.chkGravelorded);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "VeryHardMod";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblGamePath;
        private System.Windows.Forms.TextBox txtGamePath;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.CheckBox chkKnockback;
        private System.Windows.Forms.CheckBox chkStaminaRegen;
        private System.Windows.Forms.CheckBox chkTurnSpeed;
        private System.Windows.Forms.CheckBox chkLargerHitboxes;
        private System.Windows.Forms.CheckBox chkKnockDown;
        private System.Windows.Forms.CheckBox chkAggroMod;
        private System.Windows.Forms.CheckBox chkGravelorded;
        private System.Windows.Forms.CheckBox chkFasterBullets;
        private System.Windows.Forms.CheckBox chkHomingBullets;
        private System.Windows.Forms.ToolTip tooltip1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnOpenFolderDialog;
        private System.Windows.Forms.CheckBox chKMoreBullets;
        private System.Windows.Forms.CheckBox chkRingsBreak;
        private System.Windows.Forms.CheckBox chkWeaponBreak;
        private System.Windows.Forms.CheckBox chkNPCAggro;
        private System.Windows.Forms.CheckBox chkAttackSuperArmor;
        private System.Windows.Forms.CheckBox chkAttackThroughGuard;
        private System.Windows.Forms.CheckBox chkWeaponSourSpot;
        private System.Windows.Forms.CheckBox chkUpgradeCost;
        private System.Windows.Forms.CheckBox chkBulletEndlessHit;
        private System.Windows.Forms.CheckBox chkBulletsPentrateMap;
        private System.Windows.Forms.CheckBox chkSwoleInvaders;
        private System.Windows.Forms.CheckBox chkFlyingEnemies;
        private System.Windows.Forms.RadioButton rdbInsultingHitSounds1;
        private System.Windows.Forms.RadioButton rdbInsultingHitSounds2;
    }
}

