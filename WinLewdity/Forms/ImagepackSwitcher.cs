using CefSharp.WinForms;
using WinLewdity.Events;
using WinLewdity.Game;
using WinLewdity.Internal;
using WinLewdity.Properties;
using System.Drawing;
using WebBrowserExtensions = CefSharp.WebBrowserExtensions;
using WinLewdity_GUI.Internal.Windows;

namespace WinLewdity.Forms
{
    public partial class ImagepackSwitcher : Form
    {
        private GameView? parentForm { get; set; }

        public ImagepackSwitcher(GameView? gameform)
        {
            InitializeComponent();
            parentForm = gameform;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            ImagePack oldImagePack = Globals.userPreferences.preferredImagePack;

            Thread threadchan = new Thread(async () =>
            {
                // Swap image pack & reload
                if (oldImagePack != Globals.userPreferences.preferredImagePack)
                {
                    // Remove old graphics directory
                    Directory.Delete("./game/img", true);

                    // Compile the image packs
                    switch (Globals.userPreferences.preferredImagePack)
                    {
                        case ImagePack.Vanilla:
                            WinFunctions.CopyFilesRecursively("./source/vanillaimg", "./game/img");
                            break;

                        case ImagePack.Bees:
                            WinFunctions.CopyFilesRecursively("./source/beeesssimg", "./game/img");
                            break;

                        case ImagePack.BeesHikari_Female:
                            WinFunctions.CopyFilesRecursively("./source/beeessshikarifemaleimg", "./game/img");
                            break;

                        case ImagePack.BeesHikari_Male:
                            WinFunctions.CopyFilesRecursively("./source/beeessshikarimaleimg", "./game/img");
                            break;

                        case ImagePack.BeesParilHairExtended:
                            WinFunctions.CopyFilesRecursively("./source/beeesssparilhairstyleextendedimg", "./game/img");
                            break;

                        case ImagePack.BeesWax:
                            WinFunctions.CopyFilesRecursively("./source/beeessswaximg", "./game/img");
                            break;

                        case ImagePack.BeesOkbd:
                            WinFunctions.CopyFilesRecursively("./source/beeesssokbdimg", "./game/img");
                            break;

                        case ImagePack.Lllysmasc:
                            WinFunctions.CopyFilesRecursively("./source/lllysmascimg", "./game/img");
                            break;

                        case ImagePack.Susato:
                            WinFunctions.CopyFilesRecursively("./source/susatoimg", "./game/img");
                            break;

                        case ImagePack.Mizz:
                            WinFunctions.CopyFilesRecursively("./source/mizzimg", "./game/img");
                            break;

                        case ImagePack.MVCR:
                            WinFunctions.CopyFilesRecursively("./source/mvcrimg", "./game/img");
                            break;
                    }

                    // Reload webview
                    if (parentForm != null)
                    {
                        Invoke(() => WebBrowserExtensions.Reload(parentForm.gameBrowser));
                    }
                    //MessageBox.Show("Imagepack switch successful! This window will now close, enjoy!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //MessageBox.Show("You are already using that image pack!", "Success?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Invoke(() =>
                {
                    // Close imagepack form
                    this.Close();
                });
            });

            // Vanilla
            if (vanillaImagePackRadio.Checked)
            {
                Globals.userPreferences.preferredImagePack = ImagePack.Vanilla;
            }

            // Bees
            if (beesImagepackRadio.Checked)
            {
                Globals.userPreferences.preferredImagePack = ImagePack.Bees;
            }

            // Bees + Hikari Female
            if (beesHikariFemaleImagepackRadio.Checked)
            {
                Globals.userPreferences.preferredImagePack = ImagePack.BeesHikari_Female;
            }

            // Bees + Hikari Male
            if (beesHikariMaleImagepackRadio.Checked)
            {
                Globals.userPreferences.preferredImagePack = ImagePack.BeesHikari_Male;
            }

            // Bees + Parils + Hairstyles Extended
            if (beesParilHairExtendedImagepackRadio.Checked)
            {
                Globals.userPreferences.preferredImagePack = ImagePack.BeesParilHairExtended;
            }

            // Bees Wax
            if (beesWaxImagepackRadio.Checked)
            {
                Globals.userPreferences.preferredImagePack = ImagePack.BeesWax;
            }

            // Bees + Okbd
            if (beesOkbdImagepackRadio.Checked)
            {
                Globals.userPreferences.preferredImagePack = ImagePack.BeesOkbd;
            }

            // Lllymasc
            if (lllysmacImagepackRadio.Checked)
            {
                Globals.userPreferences.preferredImagePack = ImagePack.Lllysmasc;
            }

            // Susato
            if (susatoImagepackRadio.Checked)
            {
                Globals.userPreferences.preferredImagePack = ImagePack.Susato;
            }

            // Mizz
            if (mizzImagepackRadio.Checked)
            {
                Globals.userPreferences.preferredImagePack = ImagePack.Mizz;
            }

            // MVCR
            if (mvcrImagepackRadio.Checked)
            {
                Globals.userPreferences.preferredImagePack = ImagePack.MVCR;
            }

            // Run background thread
            applyButton.Enabled = false;
            cancelButton.Enabled = false;
            threadchan.Start();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vanillaImagePackRadio_CheckedChanged(object sender, EventArgs e)
        {
            imagepackPreviewPicBox.Image = Resources.vanilla_preview;
        }

        private void beesImagepackRadio_CheckedChanged(object sender, EventArgs e)
        {
            imagepackPreviewPicBox.Image = Resources.bees_preview;
        }

        private void beesHikariFemaleImagepackRadio_CheckedChanged(object sender, EventArgs e)
        {
            imagepackPreviewPicBox.Image = Resources.bees_hikarifemale_preview;
        }

        private void beesHikariMaleImagepackRadio_CheckedChanged(object sender, EventArgs e)
        {
            imagepackPreviewPicBox.Image = Resources.bees_hikarimale_preview;
        }

        private void beesParilHairExtendedImagepackRadio_CheckedChanged(object sender, EventArgs e)
        {
            imagepackPreviewPicBox.Image = Resources.bees_paril_hairextended_preview;
        }

        private void beesOkbdImagepackRadio_CheckedChanged(object sender, EventArgs e)
        {
            imagepackPreviewPicBox.Image = Resources.bees_okbd_preview;
        }

        private void beesWaxImagepackRadio_CheckedChanged(object sender, EventArgs e)
        {
            imagepackPreviewPicBox.Image = Resources.bees_wax_preview;
        }

        private void lllysmacImagepackRadio_CheckedChanged(object sender, EventArgs e)
        {
            imagepackPreviewPicBox.Image = Resources.lllymasc_preview;
        }

        private void susatoImagepackRadio_CheckedChanged(object sender, EventArgs e)
        {
            imagepackPreviewPicBox.Image = Resources.susato_preview;
        }

        private void mizzImagepackRadio_CheckedChanged(object sender, EventArgs e)
        {
            imagepackPreviewPicBox.Image = Resources.mizz_preview;
        }

        private void mvcrImagepackRadio_CheckedChanged(object sender, EventArgs e)
        {
            imagepackPreviewPicBox.Image = Resources.mvcr_preview;
        }

        private void ImagepackSwitcher_Load(object sender, EventArgs e)
        {
            this.Text = Globals.AppName + " " + this.Text;

            switch (Globals.userPreferences.preferredImagePack)
            {
                case ImagePack.Vanilla:
                    vanillaImagePackRadio.Checked = true;
                    break;

                case ImagePack.Bees:
                    beesImagepackRadio.Checked = true;
                    break;

                case ImagePack.BeesHikari_Female:
                    beesHikariFemaleImagepackRadio.Checked = true;
                    break;

                case ImagePack.BeesHikari_Male:
                    beesHikariMaleImagepackRadio.Checked = true;
                    break;

                case ImagePack.BeesParilHairExtended:
                    beesParilHairExtendedImagepackRadio.Checked = true;
                    break;

                case ImagePack.BeesWax:
                    beesWaxImagepackRadio.Checked = true;
                    break;

                case ImagePack.BeesOkbd:
                    beesOkbdImagepackRadio.Checked = true;
                    break;

                case ImagePack.Lllysmasc:
                    lllysmacImagepackRadio.Checked = true;
                    break;

                case ImagePack.Susato:
                    susatoImagepackRadio.Checked = true;
                    break;

                case ImagePack.Mizz:
                    mizzImagepackRadio.Checked = true;
                    break;

                case ImagePack.MVCR:
                    mvcrImagepackRadio.Checked = true;
                    break;
            }
        }
    }
}