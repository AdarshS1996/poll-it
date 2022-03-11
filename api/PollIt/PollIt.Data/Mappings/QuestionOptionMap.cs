using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollIt.Core;

namespace PollIt.Data.Mappings
{
    public class QuestionOptionMap : IEntityTypeConfiguration<QuestionOption>
    {
        public void Configure(EntityTypeBuilder<QuestionOption> builder)
        {
            builder.ToTable("tQuestionOption");

            builder.HasKey(x => x.QuestionOptionId);

            builder.HasOne(a => a.Question)
                   .WithMany(b => b.QuestionOptions)
                   .HasForeignKey(c => c.QuestionId)
                   .IsRequired();
        }
    }
}
