using Models;
using NUnit.Framework.Interfaces;
using Repositories.Tests.DataGenerators;
using Repositories.Tests.DataGenerators.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Tests.DataSources
{

    /// <summary>
    ///     Attribute to generate projects
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class FileDataSourceAttribute : Attribute, IParameterDataSource

    {

        private readonly int amountToGenerate;
        private readonly IFakeDataGenerator<File> fakeDataGenerator;

        public FileDataSourceAttribute()
        {
            fakeDataGenerator = new FileDataGenerator();
        }

        /// <summary>
        ///     Initializes fileDataSourceAttribute
        ///     and setting the amount of files to be generated
        /// </summary>
        public FileDataSourceAttribute(int amount) : this()
        {
            amountToGenerate = amount;
        }

        /// <summary>
        ///     Generate the data and return it
        /// </summary>
        /// <param name="parameter">Extra parameters given in the attribute, not in use but required due to inheritance</param>
        /// <returns>The generated data</returns>
        public IEnumerable GetData(IParameterInfo parameter)
        {
            if(amountToGenerate <= 1)
            {
                return new[] {fakeDataGenerator.Generate()};
            }
            List<File> files = fakeDataGenerator.GenerateRange(amountToGenerate)
                                                .ToList();
            return new[] {files};
        }

    }

}
