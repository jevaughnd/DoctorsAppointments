using Doc_Interface.Models;
using Doc_Interface.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Doc_Interface.Controllers
{
    public class PatientController : Controller
    {
        const string Patient_URl = "https://localhost:7205/api/PatientAPI";
        const string PARISH_ENDPOINT = "Parish";


        //PATIENT:INDEX
        public IActionResult Index()
        {
            //Succes Message
            if (TempData.ContainsKey("new-patient"))
            {
                ViewData["new-patient"] = TempData["new-patient"].ToString();
            }//-----------------------------------------------------


            var patientList = new List<Patient>();
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Patient_URl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = client.GetAsync($"{Patient_URl}/Patient").Result;
                if(response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    //Deserialise object from Json string
                    patientList = JsonConvert.DeserializeObject<List<Patient>>(data);
                }
            }
            return View(patientList);
        }







        //CREATE:GET
        [HttpGet]
        public IActionResult Create() 
        {
            Patient patient = new Patient();
            List<Parish> parishList = new List<Parish>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Patient_URl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //parish
                HttpResponseMessage parResponse = client.GetAsync($"{Patient_URl}/{PARISH_ENDPOINT}").Result;
                if (parResponse.IsSuccessStatusCode)
                {
                    var parData = parResponse.Content.ReadAsStringAsync().Result;
                    parishList = JsonConvert.DeserializeObject<List<Parish>>(parData)!;
                }

                //parishvm
                var viewModel = new PatientVM
                {
                    ParishList = parishList.Select(p => new SelectListItem
                    {
                        Text = p.ParishName,
                        Value = p.Id.ToString(),
                    }).ToList(),
                };
                return View(viewModel);
            }
        }




        //CREATE:POST
        [HttpPost]
        public IActionResult Create( PatientVM patientVM, int id)
        {
            

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Patient_URl);
                client.DefaultRequestHeaders.Accept.Clear();

                var patient = new Patient
                {
                    Id = id,
                    FullName = patientVM.FullName,
                    DOB = patientVM.DOB,
                    EmailAddress = patientVM.EmailAddress,
                    PhoneNumber = patientVM.PhoneNumber,
                    Street = patientVM.Street,
                    Town = patientVM.Town,
                    ParishId = patientVM.SelectedParishId
                };

                var json = JsonConvert.SerializeObject(patient);
                var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponse = client.PostAsync($"{Patient_URl}/PatientPost", data).Result;
                if (httpResponse.IsSuccessStatusCode)
                {
                    TempData["new-patient"] = "New Patient Added"; // Succes message displayed in index
                    return RedirectToAction("Index");
                    //return View(customerVm);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "You do not have permission to create patient");
                    return View(patientVM);
                }


            }
        }














        public IActionResult Update()
        {
            return View();
        }















        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }



        [HttpPost]
        public IActionResult Delete()
        {
            return View();
        }











    }
}
