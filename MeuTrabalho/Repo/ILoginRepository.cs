namespace MeuTrabalho.Repo
{
    public interface ILoginRepository
    {
        bool UsuarioValido(string email, string password);
    }
}
