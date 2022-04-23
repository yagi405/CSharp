using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsSample
{
    public class Program
    {
        private static void Main()
        {
            var target = new Sample()
            {
                //属性による検証NG
                Foo = null,
                Bar = "",
                Baz = 0

                //IValidatableObjectによる検証NG
                //Foo = "foo",
                //Bar = "bar",
                //Baz = 5,

                //検証OK
                //Foo = "foo",
                //Bar = "foo",
                //Baz = 4,
            };

            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(
                target,
                new ValidationContext(target),
                results,
                true
                );

            if (isValid)
            {
                Console.WriteLine($"{nameof(target)} is valid");
                return;
            }

            foreach (var r in results)
            {
                Console.WriteLine(r.ErrorMessage);
            }

        }
    }

    public class Sample : IValidatableObject
    {
        [Required]
        public string Foo { get; set; }

        [Display(Name = "バー")]
        [Required(ErrorMessage = "{0} は必須です。")]
        public string Bar { get; set; }

        [Range(1, 10)]
        public int Baz { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Foo != Bar)
            {
                yield return new ValidationResult(
                    $"{nameof(Foo)} と {nameof(Bar)} が異なります。",
                    new[] { nameof(Bar) }
                    );
            }

            if (Baz % 2 != 0)
            {
                yield return new ValidationResult(
                    $"{nameof(Baz)} が奇数です。",
                    new[] { nameof(Baz) }
                );
            }
        }
    }
}
