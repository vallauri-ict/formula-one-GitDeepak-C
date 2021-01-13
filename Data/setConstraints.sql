ALTER TABLE [dbo].[Drivers]  WITH CHECK ADD  CONSTRAINT [FK_Drivers_Countries] FOREIGN KEY([extCountry])
REFERENCES [dbo].[Countries] ([countryCode])

ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Countries] FOREIGN KEY([extCountry])
REFERENCES [dbo].[Countries] ([countryCode])

ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Drivers_First] FOREIGN KEY([extFirstDriver])
REFERENCES [dbo].[Drivers] ([driverNumber])

ALTER TABLE [dbo].[Circuits]  WITH CHECK ADD  CONSTRAINT [FK_Circuits_Countries] FOREIGN KEY([extCountry])
REFERENCES [dbo].[Countries] ([countryCode])

ALTER TABLE [dbo].[Races]  WITH CHECK ADD  CONSTRAINT [FK_Races_Circuits] FOREIGN KEY([extCircuit])
REFERENCES [dbo].[Circuits] ([id])

ALTER TABLE [dbo].[RacesPoints]  WITH CHECK ADD  CONSTRAINT [FK_RacesPoints_Races] FOREIGN KEY([extRace])
REFERENCES [dbo].[Races] ([idRace])