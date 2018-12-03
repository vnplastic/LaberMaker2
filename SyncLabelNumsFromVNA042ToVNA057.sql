update VNA057TB04_Customer_Job_Info 
set VNA057TB04_Customer_Job_Info.NextUniqueLabelNo=VNA042TB03_Profile.LastProfileLabelNo+1 
FROM VNA057TB04_Customer_Job_Info join VNA042TB03_Profile 
ON VNA057TB04_Customer_Job_Info.CustNo= VNA042TB03_Profile.CustNo

update VNA057TB02_Job set Printed=1 from VNA057TB02_Job join VNA042TB04_Job
ON VNA057TB02_Job.SalesOrderName=VNA042TB04_Job.SalesOrderNo
AND VNA057TB02_Job.JobTypeId=VNA042TB04_Job.JobTypeId
where VNA042TB04_Job.printed=1 

update VNA057TBA1_Carton_Job set Printed=1 from VNA057TBA1_Carton_Job join VNA042TB04_Job
ON VNA057TBA1_Carton_Job.SalesOrderName=VNA042TB04_Job.SalesOrderNo
where VNA042TB04_Job.printed=1 


update VNA057TBB1_Pallet_Job set Printed=1 from VNA057TBB1_Pallet_Job join VNA042TB04_Job
ON VNA057TBB1_Pallet_Job.SalesOrderName=VNA042TB04_Job.SalesOrderNo
where VNA042TB04_Job.printed=1 