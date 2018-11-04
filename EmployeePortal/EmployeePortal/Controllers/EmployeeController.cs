using EmployeePortal.Interfaces;
using EmployeePortal.Repositories;
using EmployeePortal.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace EmployeePortal.Controllers
{

    public class EmployeeController : ApiController
    {

        private readonly IRepository<EmployeeViewModel> repository;

        public EmployeeController(IRepository<EmployeeViewModel> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<EmployeeViewModel> GetAllEmployee()
        {
            return repository.GetAll();
        }


        [HttpGet]
        public EmployeeViewModel GetEmployee(int Id)
        {
            var data = repository.Get(Id);
            if (data != null)
            {
                return data;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
        }

        [HttpPost]
        public HttpResponseMessage AddEmployee(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = repository.Add(model);
                    if (result)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, "Submitted Successfully");
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !");
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !", ex);
            }
        }


        [HttpPut]
        public HttpResponseMessage UpdateEmployee(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = repository.Update(model);
                    if (result)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully");
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something wrong !");
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong !", ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteEmployee(int Id)
        {
            var result = repository.Delete(Id);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something wrong !");
            }
        }
    }
}
