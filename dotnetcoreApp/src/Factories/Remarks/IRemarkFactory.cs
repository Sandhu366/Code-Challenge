using ApplicationShared.Remarks.Commands;
using Domain;

namespace Factories.Remarks
{
    public interface IRemarkFactory
    {
        Remark UpdateRemark(Remark destination, EditRemarkCommand source);
    }
}
