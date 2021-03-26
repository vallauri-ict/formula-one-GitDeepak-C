CREATE PROCEDURE [dbo].[GenerateStats] 
  @driverId INT 
AS 
  DECLARE @points INT 
  DECLARE @winCount INT 
  DECLARE @secondCount INT 
  DECLARE @thirdCount INT  
  DECLARE @fastCount INT 
  DECLARE @poleCount INT 
  DECLARE @pointsAvg FLOAT 

  IF NOT EXISTS (select * from sysobjects where name='Stats' and xtype='U') 
  BEGIN 
    CREATE TABLE [Stats] ( 
      [driver_id] INT PRIMARY KEY, 
      [points] INT,  
      [win_count] INT,  
      [second_count] INT, 
      [third_count] INT, 
      [fast_count] INT, 
      [pole_count] INT, 
      [points_avg] FLOAT, 
    )
  END 
  IF EXISTS (select * from sysobjects where name='Drivers' and xtype='U') 
  BEGIN 
    SELECT @points=points FROM [Scores] WHERE [Scores].extDriver=@driverId
    SELECT @winCount=COUNT(*) FROM [RacesPoints] WHERE [RacesPoints].extDriver=@driverId AND extPos=1 
    SELECT @secondCount=COUNT(*) FROM [RacesPoints] WHERE [RacesPoints].extDriver=@driverId AND extPos=2 
    SELECT @thirdCount=COUNT(*) FROM [RacesPoints] WHERE [RacesPoints].extDriver=@driverId AND extPos=3 
    SELECT @poleCount=COUNT(*) FROM [RacesPoints] WHERE [RacesPoints].extDriver=@driverId AND extPos<=3 
    SELECT @fastCount=COUNT(*) 
    FROM [RacesPoints] 
      INNER JOIN (SELECT extRace,MIN(fastestLap) fl FROM [RacesPoints] GROUP BY extRace) a ON a.extRace=[RacesPoints].extRace AND a.fl=[RacesPoints].fastestLap 
    WHERE [RacesPoints].extDriver=@driverId 
      
    SELECT @pointsAvg=AVG(points) FROM [Scores] WHERE [Scores].extDriver=@driverId 
  END 
  IF EXISTS (select * from [Stats] WHERE driver_id=@driverId) 
  BEGIN 
    UPDATE [Stats] SET 
      points=@points, 
      win_count=@winCount, 
      second_count=@secondCount, 
      third_count=@thirdCount, 
      fast_count=@fastCount, 
      pole_count=@poleCount, 
      points_avg=@pointsAvg 
    WHERE driver_id=@driverId
  END 
  ELSE  
  BEGIN 
    INSERT INTO [Stats] VALUES( 
      @driverId, 
      @points, 
      @winCount, 
      @secondCount, 
      @thirdCount, 
      @fastCount, 
      @poleCount, 
      @pointsAvg 
    ) 
  END 
RETURN 0;