using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectManager.BussinessLayer;
using ProjectManager.Entities;

namespace UserManagerServiceWebApi.Controllers
{
    public class UserController : ApiController
    {
        private UBusinessLayer bl = new UBusinessLayer();

        // GET: api/GetAllUsers
        [HttpGet]
        [Route("api/GetAllUsers")]
        public IQueryable<UserTable> GetAllUsers()
        {
            return bl.GetAllUsers();
        }

        // GET: api/GetUserSummary
        [HttpGet]
        [Route("api/GetUserSummary")]
        public List<UserTable> GetUserSummary()
        {
            return bl.GetUserSummary();
        }

        // GET: api/GetUser/5
        [HttpGet]
        [ResponseType(typeof(UserTable))]
        [Route("api/GetUser/{id}")]
        public IHttpActionResult GetUser(int id)
        {
            List<UserTable> Users = bl.GetAllUsers().Where(i => i.UserId.Equals(id)).ToList();
            if (Users == null)
            {
                return NotFound();
            }

            return Ok(Users[0]);
        }

        // PUT: api/UpdateUser
        [HttpPut]
        [Route("api/UpdateUser")]
        public IHttpActionResult UpdateUser(UserTable Users)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bl.Update(Users.UserId, Users);
                }
                catch (Exception)
                {
                    return Ok("Error is occured during updated !");
                }
                return Ok("Record is updated Sucessfully !");

            }
            return Ok();
        }

        // POST: api/AddUser
        [HttpPost]
        [Route("api/AddUser")]
        public IHttpActionResult AddUser(UserTable Users)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bl.Add(Users);
                }
                catch (Exception)
                {
                    return Ok("Error is occured during inserted !");
                }
                return Ok("Record is added Sucessfully !");

            }
            return Ok();
        }

        // Delete: api/DeleteUser
        [HttpDelete]
        [Route("api/DeleteUser/{id}")]
        public IHttpActionResult DeleteUser(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bl.Delete(id);
                }
                catch (Exception)
                {
                    return Ok("Error is occured during deleted !");
                }
                return Ok("Record is deleted Sucessfully !");

            }
            return Ok();
        }
        }
    }
