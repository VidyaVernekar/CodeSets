using MediatR;
using PatientDetails.Commands;
using PatientDetails.Models;
using PatientDetails.Services;

namespace PatientDetails.Handlers
{
    public class DeletePatientInfoHandler : IRequestHandler<DeletePatientInfoCommand>
    {
        private IPatientinfoService _patientinfo;
        public DeletePatientInfoHandler(IPatientinfoService patientinfo)
        {
            _patientinfo = patientinfo;
        }

        public Task<Unit> Handle(DeletePatientInfoCommand request, CancellationToken cancellationToken)
        {
            _patientinfo.DeletePatientInfo(request.patientInfo);
            return Task.FromResult(Unit.Value);
        }
    }
}


