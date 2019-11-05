using Newtonsoft.Json;
using System;

namespace AsyncRequests.Models
{
    public class GithubUser
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        private string _login;
        [JsonProperty(PropertyName = "login")]
        public string Login
        {
            get => $"Login: {_login}";
            set => _login = value;
        }
        [JsonProperty(PropertyName = "node_id")]
        public string NodeId { get; set; }
        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonProperty(PropertyName = "gravatar_id")]
        public string GravatarId { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "html_url")]
        public string HtmlUrl { get; set; }
        [JsonProperty(PropertyName = "followers_url")]
        public string FollowersUrl { get; set; }
        [JsonProperty(PropertyName = "following_url")]
        public string FollowingUrl { get; set; }
        [JsonProperty(PropertyName = "gists_url")]
        public string GistsUrl { get; set; }
        [JsonProperty(PropertyName = "starred_url")]
        public string StarredUrl { get; set; }
        [JsonProperty(PropertyName = "subscriptions_url")]
        public string SubscriptionsUrl { get; set; }
        [JsonProperty(PropertyName = "organizations_url")]
        public string OrganizationsUrl { get; set; }
        [JsonProperty(PropertyName = "repos_url")]
        public string ReposUrl { get; set; }
        [JsonProperty(PropertyName = "events_url")]
        public string EventsUrl { get; set; }
        [JsonProperty(PropertyName = "received_events_url")]
        public string ReceivedEventsUrl { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "site_admin")]
        public bool SiteAdmin { get; set; }

        private string _name;
        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get => $"Nome: {_name}";
            set => _name = value;
        }
        [JsonProperty(PropertyName = "company")]
        public string Company { get; set; }
        [JsonProperty(PropertyName = "blog")]
        public string Blog { get; set; }
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "hireable")]
        public string Hireable { get; set; }
        [JsonProperty(PropertyName = "bio")]
        public string Bio { get; set; }
        [JsonProperty(PropertyName = "public_repos")]
        public int PublicRepos { get; set; }
        [JsonProperty(PropertyName = "public_gists")]
        public int PublicGists { get; set; }
        [JsonProperty(PropertyName = "followers")]
        public int Followers { get; set; }
        [JsonProperty(PropertyName = "following")]
        public int Following { get; set; }

        private DateTime _createdAt;
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt
        {
            get => $"Criado em: {_createdAt}";
            set => _createdAt = DateTime.Parse(value);
        }

        private DateTime _updatedAt;
        [JsonProperty(PropertyName = "updated_at")]
        public string UpdatedAt
        {
            get => $"Atualizado em: {_updatedAt}";
            set => _updatedAt = DateTime.Parse(value);
        }
    }
}
