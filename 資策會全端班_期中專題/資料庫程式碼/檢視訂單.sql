select 訂單ID, 班級名稱, 店家名稱, 最後修改時間 as 訂單送出時間 from [訂單] as ouo
                    inner join [班級] as cl on cl.班級ID = ouo.班級ID
                    inner join [店家] as st on st.店家ID = ouo.店家ID
                    where 最後修改時間 is not null