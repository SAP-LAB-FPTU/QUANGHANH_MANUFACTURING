CREATE TABLE Documentary_Inspection_details(
start_date datetime,
end_date datetime,
documentary_id nvarchar (150) references Documentary(documentary_id),
equipmentId nvarchar (150) references Equipment(equipmentId)
)