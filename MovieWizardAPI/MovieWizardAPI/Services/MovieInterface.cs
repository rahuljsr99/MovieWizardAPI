using MovieWizardAPI.Data;


namespace MovieWizardAPI.Services
{
    public interface IDirectors
    {
        public List<Directors> getDirector(DirectorsDbContext DContext);    
    }
}
