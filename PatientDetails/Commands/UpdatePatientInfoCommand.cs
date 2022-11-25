using MediatR;
using PatientDetails.Models;

namespace PatientDetails.Commands
{
    public record UpdatePatientInfoCommand(int id,PatientInfo patientInfo) : IRequest<PatientInfo>;

    public record IsExistsPatientInfoCommand(int id) : IRequest<bool>;

    public record IsExistsLoginCommand(string username, string password) : IRequest<Login>;

}
