using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.DataAccessVw
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FileStoragePage : ContentPage
    {
        private String folderName = "MySubFolder";
        private String fileName = "answer.txt";

        public FileStoragePage()
        {
            InitializeComponent();
        }

        public async Task SaveFile()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync(folderName,
                CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync(fileName,
                CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(answerText.Text);
            await DisplayAlert("Answer", "Saved", "OK");
        }

        public async Task ReadFile()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.GetFolderAsync(folderName);
            IFile file = await folder.GetFileAsync(fileName);
            var answer = await file.ReadAllTextAsync();
            await DisplayAlert("Answer", $"...is: {answer}", "OK");
            answerText.Text = answer;
        }

        private async void saveBtn_Clicked(object sender, EventArgs e)
        {
            await SaveFile();
        }

        private async void loadBtn_Clicked(object sender, EventArgs e)
        {
            await ReadFile();
        }
    }
}