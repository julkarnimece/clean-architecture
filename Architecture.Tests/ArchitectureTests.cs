using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Architecture.Tests
{
    public class ArchitectureTests
    {

        private const string DomainNamespace = "Domain";
        private const string ApplicationNamespace = "Application";
        private const string InfrastructureNamespace = "Infrastructure";
        private const string WebNamespace = "Web";
        private const string PresentationNamespace = "Presentation";


        //[Fact]
        //public void Domain_Should_not_HaveDependencyOnOtherProjects()
        //{

        //    //Arrange 

        //    var assembly = typeof(Domain.AssemblyReference).Assembly;

        //    var otherProjects = new[]
        //    {
        //        ApplicationNamespace,
        //        InfrastructureNamespace,
        //        WebNamespace,
        //        PresentationNamespace
        //    };

        //    //Act
        //    var testResult = Types.InAssembly(assembly).ShouldNot().HaveDepenecyOnAll(otherProjects).GetResult();


        //    //Assert

        //    testResult.IsSuccessful.Should().BeTrue($"Domain project should not depend on {string.Join(", ", otherProjects)} projects");
        //}


        //[Fact]
        //public void Application_Should_not_HaveDependencyOnOtherProjects()
        //{

        //    //Arrange 

        //    var assembly = typeof(Application.AssemblyReference).Assembly;

        //    var otherProjects = new[]
        //    {
        //        InfrastructureNamespace,
        //        WebNamespace,
        //        PresentationNamespace
        //    };

        //    //Act
        //    var testResult = Types.InAssembly(assembly).ShouldNot().HaveDepenecyOnAll(otherProjects).GetResult();


        //    //Assert

        //    testResult.IsSuccessful.Should().BeTrue($"Domain project should not depend on {string.Join(", ", otherProjects)} projects");
        //}



        //[Fact]
        //public void Infrastructure_Should_not_HaveDependencyOnOtherProjects()
        //{

        //    //Arrange 

        //    var assembly = typeof(Infrastructure.AssemblyReference).Assembly;

        //    var otherProjects = new[]
        //    {
        //        WebNamespace,
        //        PresentationNamespace
        //    };

        //    //Act
        //    var testResult = Types.InAssembly(assembly).ShouldNot().HaveDepenecyOnAll(otherProjects).GetResult();


        //    //Assert

        //    testResult.IsSuccessful.Should().BeTrue($"Domain project should not depend on {string.Join(", ", otherProjects)} projects");
        //}



        //[Fact]
        //public void Presentation_Should_not_HaveDependencyOnOtherProjects()
        //{

        //    //Arrange 

        //    var assembly = typeof(Presentation.AssemblyReference).Assembly;

        //    var otherProjects = new[]
        //    {
        //        WebNamespace,
        //        InfrastructureNamespace
        //    };

        //    //Act
        //    var testResult = Types.InAssembly(assembly).ShouldNot().HaveDepenecyOnAll(otherProjects).GetResult();


        //    //Assert

        //    testResult.IsSuccessful.Should().BeTrue($"Domain project should not depend on {string.Join(", ", otherProjects)} projects");
        //}

    }
}
