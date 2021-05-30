using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MAL_DAL
{
    public static class DatabaseOperations
    {
        /// <summary>
        /// Deze methode neemt de data van table Anime, Studio en Collection via de table
        /// AnimeCollection en sorteert deze bij naam.
        /// </summary>
        public static List<Anime> OphalenAnimes()
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.Anime
                    .Include(x => x.AnimeCollection.Select(sub => sub.Collections))
                    .Include(x => x.Studios)
                    .OrderBy(x => x.name)
                    .ToList();
            }
        }

        /// <summary>
        /// Deze methode haalt de bijhorende Collection van de User.
        /// </summary>
        public static List<AnimeCollection> OphalenAnimeCollectie(int collection)
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.AnimeCollection
                    .Where(x => x.collectionId == collection)
                    .Include(x => x.Animes)
                    .ToList();
            }
        }

        /// <summary>
        /// Deze methode haalt alle studio's op.
        /// </summary>
        public static List<Studio> OphalenStudio()
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities()) 
            {
                return project_MALEntities.Studio
                    .Include(x => x.Anime)
                    .OrderBy(x => x.name)
                    .ToList();
            }
        }

        /// <summary>
        /// Deze mthode haalt alle studio's op via hun id en stelt deze gelijk aan de
        /// variabele in de Helper klasse.
        /// </summary>
        public static Studio OphalenStudioViaId()
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.Studio
                    .Include(x => x.Anime)
                    .Where(x => x.studioId == Helper.studioId)
                    .SingleOrDefault();
            }
        }

        /// <summary>
        /// Deze methode haalt alle collecties op met hun data.
        /// </summary>
        public static List<Collection> OphalenCollectie()
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.Collection
                    .Include(x => x.AnimeCollection.Select(sub => sub.Animes))
                    .Include(x => x.Users)
                    .OrderBy(x => x.name)
                    .ToList();
            }
        }

        /// <summary>
        /// Deze methode haalt alle animes op via hun id en include de studio's en de genre's.
        /// </summary>
        public static Anime OphalenAnimesViaId()
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.Anime
                    .Include(x => x.AnimeCollection)
                    .Include(x => x.AnimeGenre.Select(sub => sub.Genres))
                    .Include(x => x.Studios)
                    .Where(x => x.animeId == Helper.animeId)
                    .OrderBy(x => x.name)
                    .SingleOrDefault();
            }
        }

        /// <summary>
        /// Deze haalt alle gebruikers op met zijn collecties met hierbij de bijhorende animes.
        /// </summary>
        public static List<User> OphalenUsers()
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.User
                    .Include(x => x.Collection.Select(sub => sub.AnimeCollection.Select(sub2 => sub2.Animes)))
                    .Include(x => x.Collection)
                    .OrderBy(x => x.name)
                    .ToList();
            }
        }

        /// <summary>
        /// Deze methode haalt alle lijsten op van de bijhorende gebruiker.
        /// </summary>
        public static List<Collection> OphalenLijstenPerGebruiker(int user)
        {
            using (Project_MALEntities project_MALEntities = new Project_MALEntities())
            {
                return project_MALEntities.Collection
                    .Where(x => x.userId == user)
                    .OrderBy(x => x.name)
                    .ToList();
            }
        }

        /// <summary>
        /// Deze methode zorgt voor het aanpassen van lijst namen.
        /// </summary>
        public static int AanpassenNaamLijst(Collection collection)
        {
            try
            {
                using (Project_MALEntities project_MALEntities = new Project_MALEntities())
                {
                    project_MALEntities.Entry(collection).State = EntityState.Modified;
                    return project_MALEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }

        /// <summary>
        /// Deze methode zorgt voor het verwijderen van lijsten.
        /// </summary>
        public static int VerwijderenLijst(Collection collection)
        {
            try
            {
                using (Project_MALEntities project_MALEntities = new Project_MALEntities())
                {
                    project_MALEntities.Entry(collection).State = EntityState.Deleted;
                    return project_MALEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }

        /// <summary>
        /// Deze methode zorgt voor het verwijderen van animes.
        /// </summary>
        public static int VerwijderenAnime(Anime anime)
        {
            try
            {
                using (Project_MALEntities project_MALEntities = new Project_MALEntities())
                {
                    project_MALEntities.Entry(anime).State = EntityState.Deleted;
                    return project_MALEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }

        /// <summary>
        /// Deze methode zorgt voor het toevoegen van lijsten.
        /// </summary>
        public static int ToevoegenLijst(Collection collection)
        {
            try
            {
                using (Project_MALEntities project_MALEntities = new Project_MALEntities())
                {
                    project_MALEntities.Collection.Add(collection);
                    return project_MALEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }

        /// <summary>
        /// Deze methode maakt het mogelijk voor het toevoegen van een nieuwe animes.
        /// </summary>
        public static int ToevoegenNieuweAnime(Anime anime)
        {
            try
            {
                using (Project_MALEntities project_MALEntities = new Project_MALEntities())
                {
                    project_MALEntities.Anime.Add(anime);
                    return project_MALEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }

        /// <summary>
        /// Deze methode maakt het mogelijk om een huidige anime toe te voegen.
        /// </summary>
        public static int ToevoegenBestaandeAnime(Anime anime)
        {
            try
            {
                using (Project_MALEntities project_MALEntities = new Project_MALEntities())
                {
                    project_MALEntities.Anime.Add(anime);
                    return project_MALEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }
    }
}
