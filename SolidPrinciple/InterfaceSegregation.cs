using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidPrinciple.InterfaceSegregation;

class Document
{

}
//We should splite large interface into smaller and more specific ones.
interface IMachine
{
    void Print(Document d);
    void Scan(Document d);
    void Fax(Document d);
}

//Split to 
interface IPrinter
{
    void Print(Document d);
}

interface IScanner
{
    void Scan(Document d);
}


class MultipleFunctionPrinter : IMachine
{
    public void Fax(Document d)
    {
        throw new NotImplementedException();
    }

    public void Print(Document d)
    {
        throw new NotImplementedException();
    }

    public void Scan(Document d)
    {
        throw new NotImplementedException();
    }
}