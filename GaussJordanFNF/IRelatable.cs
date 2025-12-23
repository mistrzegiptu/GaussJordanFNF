namespace GaussJordanFNF
{
    internal interface IRelatable
    {
        bool IsDependent(IRelatable other);
    }
}
