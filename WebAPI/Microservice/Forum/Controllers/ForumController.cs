﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthMiddleware;
using Forum.Models.View;
using Forum.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ForumController : ControllerBase
    {
        IForumManagerView Manager;

        private UserIdentity Identity
        {
            get
            {
                return this.User is null ? null : new UserIdentity(this.User);
            }
        }

       
        public ForumController(IForumManagerView forumManager)
        {
            this.Manager = forumManager;
        }

        [HttpGet("myforum")]
        public ActionResult<List<ForumView>> GetMyForum()
        {
            List<ForumView> forums = this.Manager.GetForumsOfUser(this.Identity);
            return this.Ok(forums);
        }

        [HttpPost("create")]
        public ActionResult<ForumView> CreateForum([FromBody] ForumForm value)
        {
            ForumView forum = this.Manager.CreateForum(value,this.Identity);
            return this.Ok(forum);
        }

        [HttpPost("search")]
        public ActionResult<ForumSearchView> SearchForums([FromBody] ForumSearchView search)
        {
            ForumSearchView searchResult = this.Manager.SearchForums(search, this.Identity);
            return this.Ok(searchResult);
        }

        [HttpGet("subscribe/{id}")]
        public ActionResult<string> SubForum(string id)
        {
            string result = this.Manager.UserSubscribe(id, this.Identity);
            return this.Ok(result);
        }

        [HttpGet("panel/{id}")]
        public ActionResult<string> GetForumPanel(string id)
        {
            ForumPanelView result = this.Manager.GetForumPanel(id, this.Identity);
            return this.Ok(result);
        }

    }
}
