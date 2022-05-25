using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollIt.Core;

namespace PollIt.Data.Mappings
{
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("tQuestion");

            builder.HasKey(x => x.QuestionId);

            builder.HasMany(e => e.QuestionOptions)
                .WithOne(v => v.Question)
                .HasForeignKey(v => v.QuestionId);
        }
    }
}
