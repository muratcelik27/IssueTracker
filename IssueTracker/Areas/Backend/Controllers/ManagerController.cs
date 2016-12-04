﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IssueTracker.Models;

namespace IssueTracker.Areas.Backend.Controllers
{
    public class ManagerController : AppCode.BaseController
    {
        // GET: Backend/Home
        public ActionResult Index()
        {
            List<Team> Teams = this.oIssueTrackerUnitOfWork.TeamRepository.Select().ToList<Team>();
            ViewData["Teams"] = Teams;
            List<State> States = this.oIssueTrackerUnitOfWork.StateRepository.Select().ToList<State>();
            ViewData["States"] = States;

            List<Models.Type> Types = this.oIssueTrackerUnitOfWork.TypeRepository.Select().ToList<Models.Type>();
            ViewData["Types"] = Types;

            return View();
        }

        [HttpPost]
        public ActionResult CreateTeam(Team oTeam)
        {
            try
            {
                this.oIssueTrackerUnitOfWork.TeamRepository.Save(oTeam);

                if (this.oIssueTrackerUnitOfWork.Save())
                {
                    this.oResultData.Status = AppCode.StatusEnum.Active;
                    this.oResultData.Data = oTeam;
                    this.oResultData.Message = "Team Create Successful.";
                    return Json(oResultData);
                }

                throw new Exception(oIssueTrackerUnitOfWork.GetValidationErrors());
            }
            catch (Exception ex)
            {
                this.oResultData.Status = AppCode.StatusEnum.Pasive;
                this.oResultData.Message = oIssueTrackerUnitOfWork.GetValidationErrors();
                return Json(oResultData);
            }
        }
    }
}