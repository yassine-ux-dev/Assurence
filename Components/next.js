const sql = require("msnodesqlv8");

const connectionString =
  "Server=DESKTOP-S81CTPL\\SQL2019;Database=MyDataBase;User Id=sa;Password=yassinesankou7;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=true;TrustServerCertificate=True";
const query = "SELECT * from Client";

sql.query(connectionString, query, (err, row) => {
  console.log(row);
});
