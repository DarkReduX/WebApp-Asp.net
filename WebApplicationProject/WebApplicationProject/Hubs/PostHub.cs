using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using WebApplicationProject.Entities;
using WebApplicationProject.Models;
using WebApplicationProject.Repository;

namespace WebApplicationProject.Hubs
{
    [HubName("postHub")]
    public class PostHub : Hub
    {
        public Task Like(int postId)
        {
            var likePost = SaveLike(postId);
            return Clients.All.updateLikeCount(likePost);
        }
        private LikePost SaveLike(int newsId)
        {
            var postId = newsId;
            var postRepository = new PostRepository();
            var item = postRepository.GetByPostId(postId);
            var liked = new Vote
            {
                NewsId = item.ID,
                UserId = item.UserId,
                post = item,
                UserLike = true
            };
            /*var dupe = item.PostLikes.FirstOrDefault(e => e.UserId == liked.UserId);
            if (dupe == null)
            {*/
                item.PostLikes.Add(liked);
            /*}
            else
            {
                dupe.UserLike = !dupe.UserLike;
            }*/
            postRepository.SaveChanges();
            var post = postRepository.GetByPostId(postId);

            return new LikePost
            {
                LikeCount = post.PostLikes.Count(e => e.UserLike)
            };
        }

    }
}
