using Microsoft.EntityFrameworkCore;
using KindergartenApp.Api.Models;

namespace KindergartenApp.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<ParentChild> ParentsChildren { get; set; }
        public DbSet<EducatorGroup> EducatorsGroups { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<DailyReport> DailyReports { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<QuickMessage> QuickMessages { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<SurveyAnswer> SurveyAnswers { get; set; }
    }
}
