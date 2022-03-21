-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE testDataPerson
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO Person (secondName, firstName, patronymic, email, telephone, idTag)
	VALUES ('������', '������', NULL, 'maximcska@cska.ru', '+79856426484', 2)

	INSERT INTO Person (secondName, firstName, patronymic, email, telephone, idTag)
	VALUES ('��������', '������', '����������', 'kirill@mail.ru', '+76542357898', 2)

	INSERT INTO Person (secondName, firstName, patronymic, email, telephone, idTag)
	VALUES ('�����', '�������', NULL, '����������', '+78987896545', 1)

	INSERT INTO Person (secondName, firstName, patronymic, email, telephone, idTag)
	VALUES ('��������', '����', '���������', 'artem@mail.ru', '+75697894235', 1)

	INSERT INTO Person (secondName, firstName, patronymic, email, telephone, idTag)
	VALUES ('�������', '�����', '����������', 'sidorov@ya.ru', '+75468791235', 4)

	INSERT INTO Person (secondName, firstName, patronymic, email, telephone, idTag) 
	VALUES ('��������', '��������', '����� ����', 'maggerramstr@gmail.com', '+74159873245', 4)

	INSERT INTO Person (secondName, firstName, patronymic, email, telephone, idTag) 
	VALUES ('��������', '������', '���������', 'timoboy@mail.ru', '+79854234565', NULL)

END
GO
