using Mysqlx.Crud;
using Valenwu;
using Valenwu.DAO;
using Valenwu.Entities;
using Xunit;

namespace ValenwuUnitTestingV2
{
    public class UnitTest1
    {
        [Fact]
        public void AddPatientTest()
        {
            // Arrange
            PatientDAO dao = new PatientDAO();
            int initialRowCount = dao.getAllPatients().Count;

            //Assert.Equal(0, initialRowCount);


            Patient patient = new Patient
            {
                LastName = "Wu",
                FirstName = "Chris",
                MiddleName = "",
                Address = "1111 Willingdon Ave.",
                Province = "BC",
                City = "Richmond",
                PostalCode = "M1M 1M1",
                BirthDate = "2000-01-01",
                PHN = "1234567890",
                Phone = "416-123-4567",
                Email = "chriswu@gmail.com",
                Occupation = "",
                Insurance = "",
                Misc = "",
                LastVisit = "",
                FirstVisit = DateTime.Now.ToString("2023-01-01")
            };

            //// Act
            int rowsaffected = dao.addOnePatient(patient);
            //int finalRowCount = dao.getAllPatients().Count;

            //// Assert
            Assert.Equal(1, rowsaffected);
            //Assert.AreEqual(initialRowCount + 1, finalRowCount);
        }
    }
}