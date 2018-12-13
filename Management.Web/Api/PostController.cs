using AutoMapper;
using Management.Model.Models;
using Management.Service;
using Management.Web.Infrastructure.Core;
using Management.Web.Infrastructure.Extensions;
using Management.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Management.Web.Api
{
    [RoutePrefix("api/post")]
    public class PostController : ApiControllerBase
    {

        #region Initalize
        private IPostService _postService;

        public PostController(IErrorService errorService, IPostService postService)
            : base(errorService)
        {
            this._postService = postService;
        }
        #endregion

        #region GetPostBySearch
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _postService.GetAll(keyword);

                var responseData = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        #endregion

        #region CreatNewPost
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, PostViewModel postVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newPost = new Post();
                    newPost.UpdatePost(postVm);
                    newPost.CreatedDate = DateTime.Now;
                    newPost.CategoryID = 1;
                    newPost.Alias = "Don't know";

                    _postService.Add(newPost);
                    _postService.Save();

                    var responseData = Mapper.Map<Post, PostViewModel>(newPost);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        #endregion

        #region GetPostById
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _postService.GetById(id);

                var responseData = Mapper.Map<Post, PostViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
        #endregion

        #region UpdatePost
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, PostViewModel postVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbPost = _postService.GetById(postVm.ID);

                    dbPost.UpdatePost(postVm);
                    dbPost.UpdatedDate = DateTime.Now;

                    _postService.Update(dbPost);
                    _postService.Save();

                    var responseData = Mapper.Map<Post, PostViewModel>(dbPost);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        #endregion

        #region Delete
        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldPost = _postService.Delete(id);
                    _postService.Save();

                    var responseData = Mapper.Map<Post, PostViewModel>(oldPost);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        #endregion
    }
}
