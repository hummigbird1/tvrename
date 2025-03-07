// 
// Main website for TVRename is http://tvrename.com
// 
// Source code available at https://github.com/TV-Rename/tvrename
// 
// Copyright (c) TV Rename. This code is released under GPLv3 https://github.com/TV-Rename/tvrename/blob/master/LICENSE.md
// 

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using JetBrains.Annotations;

namespace TVRename
{
    /// <summary>
    /// Summary for AddEditShow
    ///
    /// WARNING: If you change the name of this class, you will need to change the
    ///          'Resource File Name' property for the managed resource compiler tool
    ///          associated with all .resx files this class depends on.  Otherwise,
    ///          the designers will not be able to interact properly with localized
    ///          resources associated with this form.
    /// </summary>
    public partial class AddEditMovie : Form
    {
        private readonly MovieConfiguration selectedShow;
        private readonly TmdbCodeFinder  codeFinderForm;
        private CustomNameTagsFloatingWindow? cntfw;
        private readonly bool addingNewShow;
        private readonly TVDoc mDoc;

        public AddEditMovie([NotNull] MovieConfiguration si, TVDoc doc)
        {
            selectedShow = si;
            mDoc = doc;
            addingNewShow = si.TvdbCode == -1;
            InitializeComponent();

            SetupDropDowns(si);

            lblSeasonWordPreview.Text = TVSettings.Instance.MovieFolderFormat + "-(" +
                                        CustomMovieName.NameFor(si,
                                            TVSettings.Instance.MovieFolderFormat) + ")";

            lblSeasonWordPreview.ForeColor = Color.DarkGray;

            codeFinderForm =
                new TmdbCodeFinder(si.TmdbCode != -1 ? si.TmdbCode.ToString() : "") {Dock = DockStyle.Fill};

            codeFinderForm.SelectionChanged += MTCCF_SelectionChanged;

            pnlCF.SuspendLayout();
            pnlCF.Controls.Add(codeFinderForm);
            pnlCF.ResumeLayout();

            cntfw = null;
            chkCustomShowName.Checked = si.UseCustomShowName;
            if (chkCustomShowName.Checked)
            {
                txtCustomShowName.Text = si.CustomShowName;
            }

            chkCustomRegion.Checked = selectedShow.UseCustomRegion;
            cbRegion.Text = selectedShow.CustomRegionCode;

            UpdateCustomShowNameEnabled();

            SetupLanguages(si);

            cbDoRenaming.Checked = si.DoRename;
            cbDoMissingCheck.Checked = si.DoMissingCheck;

            SetProvider(si);
            chkManualFolders.Checked = selectedShow.UseManualLocations;
            chkAutoFolders.Checked = selectedShow.UseAutomaticFolders;
            PopulateRootDirectories(selectedShow.AutomaticFolderRoot);
            txtFolderNameFormat.Text = selectedShow.CustomFolderNameFormat;
            txtCustomMovieFileNamingFormat.Text = selectedShow.CustomNamingFormat;
            cbUseCustomNamingFormat.Checked = selectedShow.UseCustomNamingFormat;

            ActiveControl = codeFinderForm; // set initial focus to the code entry/show finder control

            foreach (string folder in selectedShow.ManualLocations)
            {
                lvManualFolders.Items.Add(folder);
            }

            PopulateAliasses();
            SetTagListText();
            EnableDisableCustomNaming();
            UpdateIgnore();
            SetMovieFolderType(si);
        }

        private void SetMovieFolderType([NotNull] MovieConfiguration si)
        {
            if (si.UseAutomaticFolders)
            {
                if (si.UseCustomFolderNameFormat)
                {
                    rdoFolderCustom.Checked = true;
                }
                else
                {
                    rdoFolderLibraryDefault.Checked = true;
                }
            }
        }

        private void SetTagListText()
        {
            System.Text.StringBuilder tl = new System.Text.StringBuilder();

            foreach (string s in CustomMovieName.TAGS)
            {
                tl.AppendLine($"{s} - {CustomMovieName.NameFor(selectedShow, s)}");
            }

            txtTagList2.Text = tl.ToString();
        }

        private void PopulateRootDirectories(string chosenValue)
        {
            cbDirectory.SuspendLayout();
            cbDirectory.Items.Clear();
            foreach (string folder in TVSettings.Instance.MovieLibraryFolders)
            {
                cbDirectory.Items.Add(folder.EnsureEndsWithSeparator());
            }

            cbDirectory.SelectedIndex = 0;
            cbDirectory.ResumeLayout();
            cbDirectory.Text = chosenValue.EnsureEndsWithSeparator();
        }

        private void PopulateAliasses()
        {
            foreach (string aliasName in selectedShow.AliasNames)
            {
                lbShowAlias.Items.Add(aliasName);
            }

            if (selectedShow.CachedData != null)
            {
                foreach (string aliasName in selectedShow.CachedData?.GetAliases())
                {
                    lbSourceAliases.Items.Add(aliasName);
                }
            }
        }

        private void SetupLanguages([NotNull] MovieConfiguration si)
        {
            chkCustomLanguage.Checked = si.UseCustomLanguage;
            if (chkCustomLanguage.Checked)
            {
                Language languageFromCode =
                    TheTVDB.LocalCache.Instance.LanguageList?.GetLanguageFromCode(si.CustomLanguageCode);

                if (languageFromCode != null)
                {
                    cbLanguage.Text = languageFromCode.Name;
                }
            }

            cbLanguage.Enabled = chkCustomLanguage.Checked;
        }

        private void SetProvider([NotNull] MovieConfiguration si)
        {
            switch (si.ConfigurationProvider)
            {
                case TVDoc.ProviderType.libraryDefault:
                case TVDoc.ProviderType.TVmaze:
                    rdoDefault.Checked = true;
                    break;

                case TVDoc.ProviderType.TheTVDB:
                    rdoTVDB.Checked = true;
                    break;

                case TVDoc.ProviderType.TMDB:
                    rdoTMDB.Checked = true;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetupDropDowns([NotNull] MovieConfiguration si)
        {
            if (TheTVDB.LocalCache.Instance.LanguageList != null) //This means that language shave been loaded
            {
                string pref = string.Empty;
                cbLanguage.BeginUpdate();
                cbLanguage.Items.Clear();
                foreach (Language l in TheTVDB.LocalCache.Instance.LanguageList)
                {
                    cbLanguage.Items.Add(l.Name);

                    if (si.CustomLanguageCode == l.Abbreviation)
                    {
                        pref = l.Name;
                    }
                }
                cbLanguage.EndUpdate();
                cbLanguage.Text = pref;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!OkToClose())
            {
                DialogResult = DialogResult.None;
                return;
            }

            SetShow();
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool OkToClose()
        {
            if (!TMDB.LocalCache.Instance.HasMovie(codeFinderForm.SelectedCode())) //todo Get add show to work with other providers
            {
                DialogResult dr = MessageBox.Show("tvdb code unknown, close anyway?", "TVRename Add/Edit Movie",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    return false;
                }
            }
            if (chkCustomLanguage.Checked && string.IsNullOrWhiteSpace(cbLanguage.SelectedItem?.ToString()))
            {
                MessageBox.Show("Please enter language for the show or accept the default preferred language", "TVRename Add/Edit Movie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return false;
            }
            if (chkAutoFolders.Checked && string.IsNullOrWhiteSpace(cbDirectory.SelectedItem.ToString()))
            {
                MessageBox.Show("Please enter base folder for this show or turn off automatic folders", "TVRename Add/Edit Movie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Folders.SelectedTab = tabPage5;
                cbDirectory.Focus();

                return false;
            }
            if (chkAutoFolders.Checked && !TVSettings.OKPath(cbDirectory.SelectedItem.ToString(), false))
            {
                MessageBox.Show("Please check the base folder is a valid one and has no invalid characters"
                    , "TVRename Add/Edit Movie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Folders.SelectedTab = tabPage5;
                cbDirectory.Focus();

                return false;
            }

            if (chkAutoFolders.Checked && rdoFolderCustom.Checked && !txtFolderNameFormat.Text.IsValidDirectory())
            {
                MessageBox.Show("Please check the custom subdirectory is a valid one and has no invalid characters"
                    , "TVRename Add/Edit Show",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Folders.SelectedTab = tabPage5;
                txtFolderNameFormat.Focus();

                return false;
            }

            return true;
        }

        #region HelpWindows

        private void pbBasics_Click(object sender, EventArgs e) => OpenInfoWindow("/#the-basics-tab");
        private void pbAdvanced_Click(object sender, EventArgs e) => OpenInfoWindow("/#the-advanced-tab");
        private void pbAliases_Click(object sender, EventArgs e) => OpenInfoWindow("/#the-show-aliases-tab");
        private void pbFolders_Click(object sender, EventArgs e) => OpenInfoWindow("/#the-folders-tab");

        private static void OpenInfoWindow(string page)
        {
            Helpers.OpenUrl($"https://www.tvrename.com/manual/user{page}");
        }

        #endregion

        private void SetShow()
        {
            int code = codeFinderForm.SelectedCode();

            selectedShow.CustomShowName = txtCustomShowName.Text;
            selectedShow.UseCustomShowName = chkCustomShowName.Checked;
            selectedShow.UseCustomLanguage = chkCustomLanguage.Checked;
            if (selectedShow.UseCustomLanguage)
            {
                selectedShow.CustomLanguageCode = TheTVDB.LocalCache.Instance.LanguageList?.GetLanguageFromLocalName(cbLanguage.SelectedItem?.ToString())?.Abbreviation
                                                  ??TVSettings.Instance.PreferredLanguageCode;
            }

            selectedShow.UseCustomRegion = chkCustomRegion.Checked;
            selectedShow.CustomRegionCode = cbRegion.Text;

            selectedShow.TmdbCode = code; //todo - fix so works with multi providers
            selectedShow.DoRename = cbDoRenaming.Checked;
            selectedShow.DoMissingCheck = cbDoMissingCheck.Checked;
            selectedShow.ConfigurationProvider = GetProviderType();
            selectedShow.AliasNames.Clear();
            selectedShow.AliasNames.AddRange(lbShowAlias.Items.OfType<string>().Distinct());

            selectedShow.ManualLocations.Clear();
            selectedShow.ManualLocations.AddRange(GetFolders());

            selectedShow.UseManualLocations = chkManualFolders.Checked;
            selectedShow.UseAutomaticFolders = chkAutoFolders.Checked;
            selectedShow.AutomaticFolderRoot = cbDirectory.Text;
            selectedShow.UseCustomFolderNameFormat = rdoFolderCustom.Checked;
            selectedShow.CustomFolderNameFormat = txtFolderNameFormat.Text;
            selectedShow.CustomNamingFormat = txtCustomMovieFileNamingFormat.Text;
            selectedShow.UseCustomNamingFormat = cbUseCustomNamingFormat.Checked;
        }

        private IEnumerable<string> GetFolders()
        {
            List<string> folders = new List<string>();
            foreach (ListViewItem item in lvManualFolders.Items.OfType<ListViewItem>())
            {
                folders.Add(item.Text);
            }
            return folders.Distinct();
        }

        private TVDoc.ProviderType GetProviderType()
        {
            if (rdoTMDB.Checked)
            {
                return TVDoc.ProviderType.TMDB;
            }
            if (rdoDefault.Checked)
            {
                return TVDoc.ProviderType.libraryDefault;
            }
            if (rdoTVDB.Checked)
            {
                return TVDoc.ProviderType.TheTVDB;
            }
            return TVDoc.ProviderType.TMDB;
        }

        private void bnCancel_Click(object sender, EventArgs e) => Close();

        private void chkCustomShowName_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCustomShowNameEnabled();
        }

        private void UpdateCustomShowNameEnabled()
        {
            txtCustomShowName.Enabled = chkCustomShowName.Checked;
        }

        private void chkAutoFolders_CheckedChanged(object sender, EventArgs e)
        {
            gbAutoFolders.Enabled = chkAutoFolders.Checked;
        }

        private void bnAddAlias_Click(object sender, EventArgs e)
        {
            AddAlias();
        }

        private void AddAlias()
        {
            string aliasName = tbShowAlias.Text;

            if (string.IsNullOrEmpty(aliasName))
            {
                return;
            }

            if (lbShowAlias.FindStringExact(aliasName) == -1)
            {
                lbShowAlias.Items.Add(aliasName);
            }

            tbShowAlias.Text = string.Empty;
        }

        private void bnRemoveAlias_Click(object sender, EventArgs e)
        {
            if (lbShowAlias.SelectedItems.Count > 0)
            {
                foreach (int i in lbShowAlias.SelectedIndices)
                {
                    lbShowAlias.Items.RemoveAt(i);
                }
            }
        }

        private void tbShowAlias_KeyDown(object sender, [NotNull] KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddAlias();
            }
        }

        private void tbShowAlias_TextChanged(object sender, EventArgs e)
        {
          bnAddAlias.Enabled = tbShowAlias.Text.Length > 0;
        }

        private void lbShowAlias_SelectedIndexChanged(object sender, EventArgs e)
        {
            bnRemoveAlias.Enabled = lbShowAlias.SelectedItems.Count > 0;
        }

        private void bnTags_Click(object sender, EventArgs e)
        {
                cntfw = new CustomNameTagsFloatingWindow(selectedShow);
                cntfw.Show(this);
                Focus();
        }

        private void chkCustomLanguage_CheckedChanged(object sender, EventArgs e)
        {
            cbLanguage.Enabled = chkCustomLanguage.Checked;
        }

        private void MTCCF_SelectionChanged(object sender, EventArgs e)
        {
            if (addingNewShow && TVSettings.Instance.DefShowAutoFolders && TVSettings.Instance.DefShowUseDefLocation)
            {
                // txtBaseFolder.Text =
                //     TVSettings.Instance.DefShowLocation.EnsureEndsWithSeparator()
                //     + TVSettings.Instance.FilenameFriendly(FileHelper.MakeValidPath(codeFinderForm.SelectedShow()?.Name));
            }
        }
        private void bnBrowseFolder_Click_1(object sender, EventArgs e)
        {
            folderBrowser.ShowNewFolderButton = true;

            if (!string.IsNullOrEmpty(txtFolder.Text))
            {
                folderBrowser.SelectedPath = txtFolder.Text;
            }

            if (string.IsNullOrWhiteSpace(folderBrowser.SelectedPath) && !string.IsNullOrWhiteSpace(cbDirectory.SelectedText))
            {
                folderBrowser.SelectedPath = cbDirectory.Text;
            }

            if (folderBrowser.ShowDialog(this) == DialogResult.OK)
            {
                txtFolder.Text = folderBrowser.SelectedPath;
            }
        }

        private void bnAdd_Click_1(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem { Text =txtFolder.Text};

            lvManualFolders.Items.Add(lvi);

            txtFolder.Text = string.Empty;

            lvManualFolders.Sort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvManualFolders.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lvManualFolders.SelectedItems)
                {
                    Helpers.OpenFolder(lvi.Text);
                }
            }
        }

        private void bnRemove_Click_1(object sender, EventArgs e)
        {
            if (lvManualFolders.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lvManualFolders.SelectedItems)
                {
                    lvManualFolders.Items.Remove(lvi);
                }
            }
        }

        private void btnIgnoreList_Click_1(object sender, EventArgs e)
        {
            IgnoreEdit ie = new IgnoreEdit(mDoc, cbDirectory.SelectedText);
            ie.ShowDialog(this);
            UpdateIgnore();
        }

        private void UpdateIgnore()
        {
            bool someIgnoredEps = cbDirectory.SelectedText.HasValue() && TVSettings.Instance.Ignore.Any(item => item.FileAndPath.StartsWith(cbDirectory.SelectedText, StringComparison.CurrentCultureIgnoreCase));

            txtIgnoreList.Visible = someIgnoredEps;
            btnIgnoreList.Visible = someIgnoredEps;
        }

        private void cbUseCustomNamingFormat_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableCustomNaming();
        }

        private void EnableDisableCustomNaming()
        {
            bool en = cbUseCustomNamingFormat.Checked;

            lbLibraryDefaultNaming.Enabled = en;
            txtCustomMovieFileNamingFormat.Enabled = en;
            lbAvailableTags.Enabled = en;
            txtTagList2.Enabled = en;
            lbLibraryDefaultNaming.Enabled = en;
            label19.Enabled = en;
            lbNamingExample.Enabled = en;
            llCustomName.Enabled = en;
        }

        private void txtCustomMovieFileNamingFormat_TextChanged(object sender, EventArgs e)
        {
            llCustomName.Text =
                CustomMovieName.NameFor(selectedShow, txtCustomMovieFileNamingFormat.Text);

            llFilenameDefaultFormat.Text = CustomMovieName.NameFor(selectedShow, TVSettings.Instance.MovieFilenameFormat);
        }

        private void txtFolderNameFormat_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
