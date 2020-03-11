using System;
using System.Collections.Generic;

namespace Blog.Domain.Entities
{
    public class Post
    {
        private Post() { }

        public Post(int postId, string title, string content, bool isActive, ApplicationUser author)
        {
            PostId = postId;
            Title = title;
            Content = content;
            Created = DateTime.Now;
            IsActive = isActive;
            Author = author;
        }

        public int PostId { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime Created { get; private set; }
        public bool IsActive { get; private set; }
        
        public ApplicationUser Author { get; private set; }
        public PostImage Image { get; private set; }
        public ICollection<Comment> Comments { get; private set; }
        public ICollection<Category> Categories { get; private set; }
    }
}
