using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.DataAccessVw
{
    public class Post : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string title;

        public int UserId { get; set; }
        public int Id { get; set; }
        public string Body { get; set; }

        public string Title {
            get { return title; }
            set { SetField(ref title, value); }
        }
 
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestServicePage : ContentPage
    {
        private string resourcesUrl = "https://jsonplaceholder.typicode.com/posts";
        private ObservableCollection<Post> posts;
        private HttpClient httpClient = new HttpClient(new NativeMessageHandler());

        public RestServicePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadPosts();
        }

        private async void LoadPosts()
        {
            string content = await httpClient.GetStringAsync(resourcesUrl);
            var loadedPosts = JsonConvert.DeserializeObject<List<Post>>(content);
            posts = new ObservableCollection<Post>(loadedPosts);
            listView.ItemsSource = posts;
        }

        private async void addBtn_Clicked(object sender, EventArgs e)
        {
            var post = new Post { Title = "Post " + DateTime.Now.Ticks };
            posts.Insert(0, post);
            var content = JsonConvert.SerializeObject(post);
            var response = await httpClient.PostAsync(resourcesUrl, new StringContent(content));
            System.Diagnostics.Debug.WriteLine($"[Post.Response]: success={response.IsSuccessStatusCode} | statusCode={response.StatusCode}");

            var responseContent = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine($"[Post.Response.Content]: {responseContent}");
            var postIdResponse = JsonConvert.DeserializeObject<Post>(responseContent);
            post.Id = postIdResponse.Id;
        }

        private async void updateBtn_Clicked(object sender, EventArgs e)
        {
            var post = listView.SelectedItem as Post;
            post.Title = "Post updated " + DateTime.Now.Ticks;
            var content = JsonConvert.SerializeObject(post);
            var resourceUrl = $"{resourcesUrl}/{post.Id}";
            var response = await httpClient.PutAsync(resourceUrl, new StringContent(content));
            System.Diagnostics.Debug.WriteLine($"[Put.Response]: success={response.IsSuccessStatusCode} | statusCode={response.StatusCode}");
        }

        private async void deleteBtn_Clicked(object sender, EventArgs e)
        {
            var post = listView.SelectedItem as Post;
            posts.Remove(post);
            var resourceUrl = $"{resourcesUrl}/{post.Id}";
            var response = await httpClient.DeleteAsync(resourceUrl);
            System.Diagnostics.Debug.WriteLine($"[Delete.Response]: success={response.IsSuccessStatusCode} | statusCode={response.StatusCode}");
        }
    }
}