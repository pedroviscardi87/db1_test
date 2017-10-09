using DB1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Exercise2()
        {
            return View();
        }

        public ActionResult Exercise3()
        {
            ViewBag.Technologies = new Technology_DAO().GetAll();
            ViewBag.Vacancies = new Vacancy_DAO().GetAll();
            ViewBag.Candidates = new Candidate_DAO().GetAll();
            return View();
        }

        public JsonResult Delete(int id)
        {
            try
            {
                if (new Candidate_DAO().Delete(id))
                    return Json(new { success = true, message = "O Candidato foi excluído com sucesso!!" }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { success = false, message = "Houve um problema na operação!!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Houve um problema na operação!!" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SaveChanges(Candidate candidate)
        {
            try
            {
                if (candidate.id > 0)
                {
                    if (new Candidate_DAO().Update(candidate))
                        return Json(new { success = true, message = "O Candidato foi alterado em nosso banco de dados!!" }, JsonRequestBehavior.AllowGet);
                    else
                        return Json(new { success = false, message = "Houve um problema na operação!!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (new Candidate_DAO().Insert(candidate))
                        return Json(new { success = true, result = Newtonsoft.Json.JsonConvert.SerializeObject(candidate), message = "O Candidato foi incluído em nosso banco de dados!!" }, JsonRequestBehavior.AllowGet);
                    else
                        return Json(new { success = false, message = "Houve um problema na operação!!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Houve um problema na operação!!" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}