insert into UserInfo (userID, email) values('stories2', 'stories282@gmail.com');
select * from UserInfo;

insert into Article (title, highlightText, imgUrl, articleContent, uploadDateTime, lastUpdateDateTime, writer) values(
'this is sample article', 'just for programming and testing', '', 'Can you see me?', GETDATE(), null, 'stories2');
insert into Article (title, highlightText, imgUrl, articleContent, uploadDateTime, lastUpdateDateTime, writer) values(
'this is second sample article', 'just for programming and testing', '', 'Hello world', GETDATE(), null, 'stories2');
select * from Article;