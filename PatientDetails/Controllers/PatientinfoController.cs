using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PatientDetails.Models;
using PatientDetails.Services;

namespace PatientDetails.Controllers
{
    [Route("api/patientinfo")]
    [ApiController]
    [Authorize]
    public class PatientinfoController : ControllerBase
    {
        private readonly IPatientinfo _context;

        public PatientinfoController(IPatientinfo context)
        {
            _context = context;
        }
     
        // GET: api/PatientInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientInfo>>> GetPatientInfos()
        {
            return await _context.GetPatientInfos();
        }

        // GET: api/PatientInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientInfo>> GetPatientInfo(int id)
        {
            var patientInfo = _context.GetPatientInfo(id);

            if (patientInfo == null)
            {
                return NotFound();
            }

            return patientInfo;
        }

        // PUT: api/PatientInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientInfo(int id, PatientInfo patientInfo)
        {
            if (id != patientInfo.Id)
            {
                return BadRequest();
            }
            try
            {
               _context.PutPatientInfo(id,patientInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PatientInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientInfo>> PostPatientInfo(PatientInfo patientInfo)
        {
            _context.PostPatientInfo(patientInfo);

            return CreatedAtAction("GetPatientInfo", new { id = patientInfo.Id }, patientInfo);
        }

        // DELETE: api/PatientInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientInfo(int id)
        {
            var patientInfo = _context.GetPatientInfo(id);
            if (patientInfo == null)
            {
                return NotFound();
            }

            _context.DeletePatientInfo(patientInfo);

            return Ok();
        }

        private bool PatientInfoExists(int id)
        {
            return _context.PatientInfoExists(id);
        }

        [Route("endpoint")]
        [HttpPost]
        public async Task<IActionResult> Save(List<PatientDetailsODSheet> patientsList)
        {
            List<PatientDetailsODSheet> formatNotCorrectList = await _context.PatientSpreedShetSave(patientsList);
           
            if (formatNotCorrectList.Count > 0 || formatNotCorrectList.Count == 0)
                return Ok(formatNotCorrectList);
            else
                return BadRequest();
        }
        private async Task<Drug> DrugExists(string drugname, string drugIdFormat)
        {
            return await _context.DrugExists(drugname, drugIdFormat);
        }
        private async Task<PatientInfo> PatientExists(string email, string name)
        {
            return await _context.PatientExists(email,name);
        }
        
    }
}
