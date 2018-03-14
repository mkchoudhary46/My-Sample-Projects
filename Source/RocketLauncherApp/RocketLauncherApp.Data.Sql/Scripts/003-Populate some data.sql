  set Identity_insert Destinations ON
  Insert into Destinations(Id,Name) values(1,'Des1')
  Insert into Destinations(Id,Name) values(2,'Des2')
  set Identity_insert Destinations off

  GO
  set Identity_insert SatelliteCategories ON
  Insert into SatelliteCategories(Id,Name) values(1,'Weather')
  Insert into SatelliteCategories(Id,Name) values(2,'Maps')
  Insert into SatelliteCategories(Id,Name) values(3,'Surveillance')
  set Identity_insert SatelliteCategories Off