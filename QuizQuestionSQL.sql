use master
create database Quizz_LearnWithPenguine
use Quizz_LearnWithPenguine

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE Quiz_Question
(
	Question_Topic nvarchar(200) NOT NULL,
	Question_ID int NOT NULL
)ON [PRIMARY]
--drop table Quiz_Question
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE Quiz_Within
(
	Question_ID int NOT NULL,
	Question nvarchar(500) NULL,
	Answer1 nvarchar(500) NULL,
	Answer2 nvarchar(500) NULL,
	Answer3 nvarchar(500) NULL,
	Answer4 nvarchar(500) NULL,
	CorrectAnswer tinyint NULL,
	CONSTRAINT Quiz_Answer PRIMARY KEY CLUSTERED 
(
	Question_ID ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
--drop table Quiz_Within



GO
SET ANSI_PADDING OFF
GO
--INSERT INTO	Quiz_Question VALUES ()
insert into Quiz_Question values ('Vietnamsnature', 1)
insert into Quiz_Question values ('Vietnamsnature', 2)
insert into Quiz_Question values ('Vietnamsnature', 3)
insert into Quiz_Question values ('Vietnamsnature', 4)
insert into Quiz_Question values ('Vietnamsnature', 5)
insert into Quiz_Question values ('Vietnamsnature', 6)
insert into Quiz_Question values ('Vietnamsnature', 7)
insert into Quiz_Question values ('Vietnamsnature', 8)
insert into Quiz_Question values ('Vietnamsnature', 9)
insert into Quiz_Question values ('Vietnamsnature', 10)
insert into Quiz_Question values ('Vietnamsnature', 11)
insert into Quiz_Question values ('Vietnamsnature', 12)
insert into Quiz_Question values ('Vietnamsnature', 13)
insert into Quiz_Question values ('Vietnamsnature', 14)
insert into Quiz_Question values ('Vietnamsnature', 15)

insert into Quiz_Question values ('Vietnamshistory', 16)
insert into Quiz_Question values ('Vietnamshistory', 17)
insert into Quiz_Question values ('Vietnamshistory', 18)
insert into Quiz_Question values ('Vietnamshistory', 19)
insert into Quiz_Question values ('Vietnamshistory', 20)
insert into Quiz_Question values ('Vietnamshistory', 21)
insert into Quiz_Question values ('Vietnamshistory', 22)
insert into Quiz_Question values ('Vietnamshistory', 23)
insert into Quiz_Question values ('Vietnamshistory', 24)
insert into Quiz_Question values ('Vietnamshistory', 25)
insert into Quiz_Question values ('Vietnamshistory', 26)
insert into Quiz_Question values ('Vietnamshistory', 27)
insert into Quiz_Question values ('Vietnamshistory', 28)
insert into Quiz_Question values ('Vietnamshistory', 29)
insert into Quiz_Question values ('Vietnamshistory', 30)

insert into Quiz_Question values ('Artwork', 31)
insert into Quiz_Question values ('Artwork', 32)
insert into Quiz_Question values ('Artwork', 33)
insert into Quiz_Question values ('Artwork', 34)
insert into Quiz_Question values ('Artwork', 35)
insert into Quiz_Question values ('Artwork', 36)
insert into Quiz_Question values ('Artwork', 37)
insert into Quiz_Question values ('Artwork', 38)
insert into Quiz_Question values ('Artwork', 39)
insert into Quiz_Question values ('Artwork', 40)
insert into Quiz_Question values ('Artwork', 41)
insert into Quiz_Question values ('Artwork', 42)
insert into Quiz_Question values ('Artwork', 43)
insert into Quiz_Question values ('Artwork', 44)
insert into Quiz_Question values ('Artwork', 45)

insert into Quiz_Question values ('Around the world', 46)
insert into Quiz_Question values ('Around the world', 47)
insert into Quiz_Question values ('Around the world', 48)
insert into Quiz_Question values ('Around the world', 49)
insert into Quiz_Question values ('Around the world', 50)
insert into Quiz_Question values ('Around the world', 51)
insert into Quiz_Question values ('Around the world', 52)
insert into Quiz_Question values ('Around the world', 53)
insert into Quiz_Question values ('Around the world', 54)
insert into Quiz_Question values ('Around the world', 55)
insert into Quiz_Question values ('Around the world', 56)
insert into Quiz_Question values ('Around the world', 57)
insert into Quiz_Question values ('Around the world', 58)
insert into Quiz_Question values ('Around the world', 59)
insert into Quiz_Question values ('Around the world', 60)



GO
insert into Quiz_Within values (1, N'Ai làm vua ở đồng lầy' + char(13) + N'Ai thường tập trận với bầy trẻ trâu' + char(13) + N'Đó là ai ?', N'Đinh Bộ Lĩnh', N'Triệu Quang Phục', N'Hai Bà Trưng', N'Đinh Bộ Lĩnh và Triệu Quang Phục', 4) 
insert into Quiz_Within values (2, N'Ba tuổi chưa nói chưa cười' + char(13) + N'Cứ nằm yên lặng nghe lời mẹ ru' + char(13) + N'Chợt nghe nước có giặc thù' + char(13) + N'Vụt cao mười trượng đánh quân thù tan xương?', N'Phù Đổng Thiên Vương', N'Đinh Bộ Lĩnh', N'Trần Quốc Toản', N'Quang Trung', 1)
insert into Quiz_Within values (3, N'Là dân, áo vải cờ đào. Dấy quân khởi nghĩa kéo vào Thăng Long. Nhân dân trên dưới một lòng. Mùng ba, Kỷ Dậu, tan tành giặc Thanh?', N'Trần Quốc Toản', N'Quang Trung', N'Nguyễn Huệ', N'Trần quốc toản', 1)
insert into Quiz_Within values (4, N'Bác Hồ đọc bảng tuyên ngôn độc lập vào ngày tháng năm nào?', '19-2-2001', '2-9-1945', '30-4-1975', N'Không có đáp án đúng', 2)
insert into Quiz_Within values (5, N'Đố ai nêu lá quốc kì' + char(13) + N'Mê Linh đất cũ còn ghi muôn đời' + char(13) + N'Yếm, khăn đội đá vá trời' + char(13) + N'Giặc Tô mất vía rụng rời thoát thân' + char(13) + N'Là ai?', N'Hai Bà Trưng', N'Bà Triệu', N'Trưng Trắc', N'Trưng Nhị', 1)
insert into Quiz_Within values (6, N'Đố ai qua Nhật, sang Tàu' + char(13) + N'Soạn thành huyết lệ lưu cầu tàn thư' + char(13) + N'Hô hào vận động Đông Du' + char(13) + N'Kết đoàn cùng với sĩ phu khắp miền' + char(13) + N'Đó là ai?', N'Nguyễn Sinh Cung', N'Phan Châu Trinh', N'Phan Bội Châu', N'Ngô Quyền', 3)
insert into Quiz_Within values (7, N'Đố ai trên Bạch Đằng giang' + char(13) + N'Làm cho cọc nhọn dọc ngang sáng ngời' + char(13) + N'Phá quân Nam Hán tơi bời' + char(13) + N'Gươm thần độc lập giữa trời vang lên' + char(13) + N'Là anh hùng nào?', N'Trần Quốc Toản', N'Hai bà Trưng', N'Ngô Quyền', N'Yết Kiêu', 3)
insert into Quiz_Within values (8, N'Lễ kỉ niệm ngày nhà giáo Việt Nam được tổ chức lần đầu tiên ở nước ta vào năm nào?', '13-11-2006', '19-5-1890', '20-11-2022', '20-11-1958', 4)
insert into Quiz_Within values (9, N'Câu hỏi vui: Ở đây có bao nhiêu chữ H? Hồ Chí Minh , hồ ao ,Hồ Quý Ly', '1', '2', '3', 'Không có đáp án nào đúng', 2)
insert into Quiz_Within values (10, N'Ngày Bác Hồ ra đi tìm đường cứu nước vào ngày tháng năm nào?', '5-6-1911', '6-5-1911', '7-6-1989', '7-8-1997', 1)
insert into Quiz_Within values (11, N'Con Tàu Đô đốc mà bác lên đường ra Pháp không phiên âm Hán Việt là?', N'La-tu-sơn- Tờ-rê-vin', N'Latuson torevin', N'Latouche-Trevillle', N'Latouche-Tréville', 4)
insert into Quiz_Within values (12, N'Vị vua nào là vị vua cuối cùng của Lịch sử phong kiến Việt Nam?', N'Minh Mạng', N'Bảo Đại', N'Hàm Nghi', N'Nguyễn Ánh', 2)
insert into Quiz_Within values (13, N'Ai là vị vua nhỏ tuổi nhất Việt Nam?', N'Trần Cảnh', N'Lê Nhân Tông', N'Duy Tân', N'Đinh Toàn', 2)
insert into Quiz_Within values (14, N'Vị vua nào được mệnh danh là "Ông vua cờ lau"?', N'Lê Hoàn', N'Ngô Quyền', N'Đinh Tiên Hoàng', N'Đinh Toàn', 3)
insert into Quiz_Within values (15, N'Ai là vị Trạng nguyên trẻ tuổi nhất nước Việt Nam?', N'Mạc Đĩnh Chi', N'Lương Thế Vinh', N'Nguyễn Bỉnh Khiêm', N'Nguyễn Hiền', 4)

insert into Quiz_Within values (16, N'Ngọn núi nào cao nhất Việt Nam và được mệnh danh là "Nóc nhà Đông Dương"?', N'Hồng Lĩnh', N'Phan Xi Păng', N'Bạch Mã', N'Langbiang', 2)
insert into Quiz_Within values (17, N'Ngôi chùa nào được tổ chức Kỷ lục châu Á xác lập kỷ lục: Ngôi chùa có kiến trúc độc đáo nhất?', N'Chùa Trấn Quốc', N'Chùa Thiên Mụ', N'Chùa Một Cột', N'Chùa Bái Đính', 3)
insert into Quiz_Within values (18, N'Hòn đảo nào được mệnh danh là hòn đảo tôm hùm?', N'Bình Hưng', N'Nam Du', N'Bình Ba', N'Cô Tô', 3)
insert into Quiz_Within values (19, N'Lý Sơn được mệnh danh là vương quốc của loại gia vị nào?', N'Tỏi', N'Hành tím', N'Hành tây', N'Ớt bột', 1)
insert into Quiz_Within values (20, N'Hòn đảo nào từng được mệnh danh là Đảo Ngọc?', N'Tuần Châu', N'Cát Bà', N'Côn Đảo', N'Phú Quốc', 4)
insert into Quiz_Within values (21, N'Ngôi chùa nào có nhiều kỷ lục được xác lập nhất? Như có tượng phật bằng đồng dát vàng lớn nhất châu Á, hành lang La Hán dài nhất châu Á, tượng Di lặc bằng đồng lớn nhất Đông Nam Á...', N'Chùa Báo Quốc', N'Chùa Dâu', N'Chùa Bái Đính', N'Chùa Hương', 3)
insert into Quiz_Within values (22, N'Nhà thờ nào được xem là nhà thờ cổ nhất, tiêu biểu và gắn liền với sự hình thành và phát triển của thành phố Đà Lạt ngàn hoa?', N'Nhà thờ Domaine de Marie', N'Nhà thờ Cam Ly', N'Nhà thờ Mai Anh', N'Nhà thờ Con Gà', 4)
insert into Quiz_Within values (23, N'Cầu dây văng đầu tiên của Việt Nam bắc qua sông Tiền có tên là gì?', N'Rạch Miễu', N'Thuận Phước', N'Mỹ Thuận', N'Nhật Tân', 3)
insert into Quiz_Within values (24, N'Huyện nào ở tỉnh Yên Bái nổi tiếng với ruộng bậc thang?', N'Lục Yên', N'Mù Cang Chải', N'Văn Chấn', N'Đồng Văn', 2)
insert into Quiz_Within values (25, N'Nơi nào là điểm cực Bắc của Việt Nam?', N'Lũng Cú', N'A Pa Chải', N'Mũi Đại Lãnh', N'Mường Lai', 1)
insert into Quiz_Within values (26, N'Địa danh nào được UNESCO công nhận là Di sản văn hóa và thiên nhiên thế giới của Việt Nam?', N'Cố đô Huế', N'Quần thể danh thắng Tràng An - Ninh Bình', N'Phố cổ Hội An', N'Vườn quốc gia Phong Nha - Kẻ Bàng', 2)
insert into Quiz_Within values (27, N'Đặc trưng của Vườn quốc gia Phong Nha - Kẻ bàng là gì?', N'Những kiến tạo đá vôi hàng triệu năm tuổi với hơn 300 hang động và hệ thống các sông ngầm', N'Lăng tẩm của các triều vua thời Nguyễn', N'Nơi giao lưu văn hóa: Việt Nam - Trung Hoa - Nhật Bản', N'Là cô đô của Việt Nam', 1)
insert into Quiz_Within values (28, N'Nơi đâu được một giáo sĩ người Pháp ngơi khen là "hải cảng đẹp nhất, nơi mà thương nhân ngoại quốc thường lui tới buôn bán"?', N'Hội An', N'Phong Nha - Kẻ Bàng', N'Huế', N'Tràng An', 1)
insert into Quiz_Within values (29, N'Hòn đảo nào của Vịnh Hạ Long được in trên mặt sau của tờ 200.000 VNĐ?', N'Hòn Trống Mái (Hòn Gà Chọi)', N'Hòn Đinh Hương (Lư Hương)', N'Hòn Con Cóc', N'Hòn Ngọc Vừng', 2)
insert into Quiz_Within values (30, N'Đây là một tỉnh phía Bắc, còn gọi là Cao nguyên đá, có nhiều cảnh đẹp và nhiều tuyến đường khúc khuỷu tuyệt vời khó quên như Hoàng Su Phù – Sín Mần, Đồng Văn – Mèo Vạc', N'Lào Cai', N'Hà Giang', N'Lai Châu', N'Cao Bằng', 2)

insert into Quiz_Within values (31, N'Trống đồng Đông Sơn là biểu tưởng của văn minh?', N'Sông Hồng', N'Sông Mã', N'Sông Cả', N'Sông Thu Bồn', 1)
insert into Quiz_Within values (32, N'Đây là một danh họa rất nổi tiếng, ông ấy tên gì nhỉ?', N'Vincent van Gogh', N'Leonardo da Vinci', N'Pablo Picasso', N'Paul Cézanne', 1)
insert into Quiz_Within values (33, N'Loài hoa trong bức tranh này tên là gì?', N'Hoa huệ', N'Hoa lan', N'Hoa hồng', N'Hoa diên vĩ', 4)
insert into Quiz_Within values (34, N'Đây là một danh họa rất nổi tiếng, ông ấy tên gì nhỉ?', N'Vincent van Gogh', N'Leonardo da Vinci', N'Pablo Picasso', N'Paul Cézanne', 2)
insert into Quiz_Within values (35, N'Đây là một loại hình sân khấu nào chỉ ở Việt Nam có, xuất hiện từ đời nhà Lý', N'Kịch', N'Múa rối', N'Múa rối nước', N'Kinh kịch', 3)
insert into Quiz_Within values (36, N'Được coi là một loại hình sân khấu của hội hè với đặc điểm sử dụng ngôn ngữ đa thanh, đa nghĩa kết hợp với cách nói ví von giàu tính tự sự, trữ tình. Đó là:', N'Chèo', N'Cải lương', N'Quan họ', N'Hát ví', 1)
insert into Quiz_Within values (37, N'Đặc thù của dân ca quan họ là gì?', N'Hát đơn ca', N'Hát đối nam nữ', N'Hát song ca', N'Hát dặm', 2)
insert into Quiz_Within values (38, N'Hát bội còn có tên gọi khác là gì?', N'Chèo', N'Cải lương', N'Múa rối nước', N'Tuồng', 4)
insert into Quiz_Within values (39, N'Là sự tổng hòa của các loại hình nghệ thuật, mang đặc trưng riêng của người Khmer. Để bắt đầu buổi biểu diễn phải thực hiện cúng tổ tại gia. Đây là ...', N'Bài chòi', N'Hồ Quảng', N'Dù kê', N'Cải lương', 3)
insert into Quiz_Within values (40, N'Đây là một di sản văn hóa phi vật thể quý giá của đất Tổ Hùng Vương, bạn có biết tên của nó là gì?', N'Tuồng', N'Hát xoan', N'Kịch nói', N'Hồ Quảng', 2)
insert into Quiz_Within values (41, N'Nghệ Tĩnh nổi tiếng với loại hình nghệ thuật nào?', N'Cải lương', N'Chèo', N'Dân ca ví giặm', N'Quan họ', 3)
insert into Quiz_Within values (42, N'Đâu là một loại hình kịch hát có nguồn gốc từ miền Nam Việt Nam, hình thành trên cơ sở dòng nhạc Đờn ca tài tử và dân ca miền đồng bằng sông Cửu Long', N'Chèo', N'Hồ Quảng', N'Dân ca', N'Cải lương', 4)
insert into Quiz_Within values (43, N'Bộ trang phục truyền thống của xứ sở "Hoa anh đào" mang tên?', N'Tomono', N'Kimono', N'Kamana', N'Yumono', 2)
insert into Quiz_Within values (44, N'Váy là trang phục truyền thống dành cho nam giới ở?', N'Đức', N'Pháp', N'Scotland', N'Nga', 3)
insert into Quiz_Within values (45, N'Tên gọi của bộ trang phục này là?', N'Váy Samba', N'Váy Tango', N'Váy Flamenco', N'Váy Disco', 3)

insert into Quiz_Within values (46, N'Đây là công trình biểu tượng cho quốc gia nào?', N'Ai Cập', N'Hy Lạp', N'Mông Cổ', N'Thổ Nhĩ Kỳ', 1)
insert into Quiz_Within values (47, N'Loại cua nào được sử dụng để làm món cua sốt ớt chilli crab ở Singapore?', N'Cua đồng', N'Cua bùn', N'Cua huỳnh đế', N'Cua đá', 2)
insert into Quiz_Within values (48, N'Ngoài vùng Tây Bắc nước ta, chẩm chéo còn được dùng làm gia vị ở quốc gia Đông Nam Á nào?', N'Philippines', N'Thái Lan', N'Indonesia', N'Brunei', 2)
insert into Quiz_Within values (49, N'Pad là tên món ăn nổi tiếng nào ở Thái Lan?', N'Gỏi miến hải sản', N'Gỏi xoài', N'Phở xào', N'Xôi xoài', 3)
insert into Quiz_Within values (50, N'Tượng Chúa Kitô cứu thế nằm trên đỉnh ngọn núi nào ở Brasil?', N'Sugarloaf Mountain', N'Corcovado', N'Pedra da Gávea', N'Pico Selado', 2)
insert into Quiz_Within values (51, N'Đảo Phục Sinh nằm ở đại dương nào?', N'Thái Bình Dương', N'Ấn Độ Dương', N'Bắc Băng Dương', N'Đại Tây Dương', 1)
insert into Quiz_Within values (52, N'Cái tên nào sau đây không phải tên gọi khác của Chùa Một Cột?', N'Chùa Mật', N'Diên Hựu Tự', N'Liên Hoa Đài', N'Chùa Nhất Tự', 4)
insert into Quiz_Within values (53, N'Nhà thờ Đức Bà được xây dựng theo phong cách kiến trúc nào?', N'Kiến trúc Byzantine', N'Kiến trúc Phục Hưng', N'Kiến trúc Gothic', N'Kiến trúc Roman', 4)
insert into Quiz_Within values (54, N'Tử Cấm Thành có bao nhiêu cung?', '700', '860', '800', '900', 3)
insert into Quiz_Within values (55, N'Quốc gia nào có ba thủ đô?', N'Nam Phi', N'Costa Rica', N'Ấn Độ', N'Afghanistan', 1)
insert into Quiz_Within values (56, N'Đâu là vị thần tượng trưng cho mặt trời và bảo hộ của các thiên hoàng', N'Susanoo', N'Uzume', N'Akira', N'Amaterasu', 4)
insert into Quiz_Within values (57, N'Nhật Bản được mệnh danh là...', N'Đất nước mặt trời lặn', N'Sứ xở kim chi', N'Sứ xở hoa anh đào', N'Đất nước sương mù', 3)
insert into Quiz_Within values (58, N'Vịnh Lan Hạ nằm ở địa phương nào?', N'Hải Phòng', N'Quảng Ninh', N'Nam Định', N'Quảng Bình', 1)
insert into Quiz_Within values (59, N'Cây bồ công anh, lau, ngô là những loại cây thụ phấn nhờ', N'Sâu bọ', N'Con người', N'Gió', N'Nước', 3)
insert into Quiz_Within values (60, N'Bạn nghĩ đâu là mối đe dọa lớn nhất cho sự sống dưới đại dương?', N'Rác thải nhựa', N'Đại dương nóng lên', N'Chất thải', N'Đánh bắt cá quá mức', 4)


--delete from Quiz_Within
--select *from Quiz_Within

alter table Quiz_Question with check add constraint Question_ID foreign key (Question_ID) 
references Quiz_Within (Question_ID)
go
alter table Quiz_Question check constraint Question_ID
go