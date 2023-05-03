using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal static class PostRepository
    {
        internal async static Task<List<Post>> GetPostsAsync()
        {
            using(var db = new AppDBContext())
            {
                return await db.Posts.ToListAsync();
            }
        }
        internal async static Task<Post> getPostByIdAsync(int postId)
        {
            using(var db = new AppDBContext())
            {
                return await db.Posts.FirstOrDefaultAsync(post => post.PostId == postId);
            }
        }
        internal async static Task<bool> CreatePostAsynch(Post post)
        {
            using(var db = new AppDBContext())
            {
                try
                {
                    await db.Posts.AddAsync(post);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdatePostAsync(Post postUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Posts.Update(postUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeletePostAsync(int postId)
        {
            using(var db = new AppDBContext())
            {
                try
                {
                    Post post = await getPostByIdAsync(postId);
                    db.Remove(post);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
    }
    
}
