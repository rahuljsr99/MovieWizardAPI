using MovieWizardAPI.Data;
using MovieWizardAPI.Entities;

namespace MovieWizardAPI.Services
{
    public interface Imovies
    {
        public List<Movies> getMovies(MovieContext movieContext);
    }
}
