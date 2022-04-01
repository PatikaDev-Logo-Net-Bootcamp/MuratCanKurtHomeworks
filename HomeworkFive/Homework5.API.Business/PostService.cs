using Homework5.API.DataAccess.EntityFramework.Repository.Abstracts;
using Homework5.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Homework5.API.Business
{
    public interface IPostService
    {
        List<Post> GetAllPosts();
        List<Post> GetUserPosts(int userId);
        Post GetById(int id);
        void AddPost(Post post);
        Task AddPost(Post post, CancellationToken cancellationToken = default);
    }
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IRepository<Post> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Post GetById(int id)
        {
            return _repository.Get(x => x.Id == id);
        }
        public List<Post> GetAllPosts()
        {
            return _repository.GetList().ToList();
        }

        public List<Post> GetUserPosts(int userId)
        {
            return _repository.GetList(x => x.UserId == userId).ToList();
        }

        public void AddPost(Post post)
        {
            _repository.Add(post);
            _unitOfWork.Commit();
        }

        public async Task AddPost(Post post, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                _repository.Add(post);
                _unitOfWork.Commit();
            }, cancellationToken);
        }
    }
}
