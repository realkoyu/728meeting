﻿using _728Meeting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _728Meeting.Controllers
{
    public class SigninController : Controller
    {
        RecordEntities recordEntities = new RecordEntities();

        // GET: Signin
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckName(CheckNameModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Signin");
            }

            var result = recordEntities.Participant.FirstOrDefault(p => p.User.Name == model.Name);
            if(result != null)
            {
                return RedirectToAction("Result", "Signin", new { Id = result.ParticipantId });
            }
            else
            {
                return RedirectToAction("Normal", "Signin");
            }
        }

        public ActionResult Result(string Id)
        {
            if (Id != null && Id.Length > 0)
            {
                var participant = recordEntities.Participant.FirstOrDefault(p => p.ParticipantId == Id);
                if (participant != null)
                {
                    return View(participant);
                }
            }
            return RedirectToAction("Index", "Signin");
        }

        public ActionResult Normal()
        {
            return View(recordEntities);
        }

        public ActionResult Hotel()
        {
            return View();
        }

        public ActionResult Visit()
        {
            return View();
        }
        
        public ActionResult Update()
        {
            //var meetingId = Guid.NewGuid().ToString();

            //            var companyTypes = new List<CompanyType>()
            //            {
            //                new CompanyType(){Name="国家部委",CompanyTypeId="4d46ffb9-a916-44d2-8d71-fa0b1c90df82",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new CompanyType(){Name="地方政府/上海市",CompanyTypeId="f6011d65-2062-4409-89be-d5e0f2734770",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new CompanyType(){Name="内部集团领导",CompanyTypeId="4dca3d82-c307-489b-884f-568fb5cdb6d7",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new CompanyType(){Name="内部集团",CompanyTypeId="c1c836b7-1e75-44cb-9513-05a17da1949e",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new CompanyType(){Name="电厂及服务",CompanyTypeId="738212f5-99ca-4c74-802a-247f1ab3454e",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new CompanyType(){Name="大学/科研院所",CompanyTypeId="38a88fd6-028e-435d-9b79-80ff2f469dca",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new CompanyType(){Name="设备/制造厂",CompanyTypeId="61e97296-f764-4907-9ac2-a973e9ccb242",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new CompanyType(){Name="其他",CompanyTypeId="39bb10d0-c010-4d46-9777-8e7da96d9d53",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //            };

            //            var companyNames = new List<Company>() {
            //                new Company(){Name="北海舰队",CompanyId="d2ff3423-bbc4-4acc-849e-5f6013560d88",CompanyTypeId="4d46ffb9-a916-44d2-8d71-fa0b1c90df82",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="中国国际工程咨询公司/能源产业发展部",CompanyId="45a35aac-2d4f-476c-aba2-0d09fa4e6d79",CompanyTypeId="4d46ffb9-a916-44d2-8d71-fa0b1c90df82",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="上海市核电办",CompanyId="682c0429-2876-4bb6-8f98-51ab03118e5f",CompanyTypeId="f6011d65-2062-4409-89be-d5e0f2734770",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="上海市经信委",CompanyId="459660f2-2ef8-4cb3-888e-6ae6818e4a57",CompanyTypeId="f6011d65-2062-4409-89be-d5e0f2734770",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="上海市科委",CompanyId="263653ac-2d01-4c23-b793-51dcd3a75bbf",CompanyTypeId="f6011d65-2062-4409-89be-d5e0f2734770",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="中国原子能科学研究院",CompanyId="d7e61816-0067-43ea-b166-d26f601f0f0a",CompanyTypeId="f6011d65-2062-4409-89be-d5e0f2734770",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="国核工程",CompanyId="a231d818-5084-47c1-afd1-e6eb9cfc5768",CompanyTypeId="c1c836b7-1e75-44cb-9513-05a17da1949e",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="国核示范",CompanyId="3779e810-ae7d-4856-b8b5-963e8cacdc95",CompanyTypeId="c1c836b7-1e75-44cb-9513-05a17da1949e",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="上海中核浦原有限公司",CompanyId="2ab90b22-fc87-4289-bb63-e1e7a861e986",CompanyTypeId="738212f5-99ca-4c74-802a-247f1ab3454e",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="三门核电有限公司",CompanyId="c2e063dd-8183-4fd3-b0c2-708296ee997d",CompanyTypeId="738212f5-99ca-4c74-802a-247f1ab3454e",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="江苏核电有限公司",CompanyId="8e611af6-2fbf-4336-8669-e0750e01434c",CompanyTypeId="738212f5-99ca-4c74-802a-247f1ab3454e",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="山东核电有限公司",CompanyId="a749e1cc-2146-427e-b16e-d2093f2bb0e1",CompanyTypeId="738212f5-99ca-4c74-802a-247f1ab3454e",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="秦山核电",CompanyId="5f8eb33b-220b-4fea-8e85-7c5d0a086e09",CompanyTypeId="738212f5-99ca-4c74-802a-247f1ab3454e",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="红沿河核电",CompanyId="4e87c107-80d4-4863-bd8f-7a2147bc7212",CompanyTypeId="738212f5-99ca-4c74-802a-247f1ab3454e",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="广东湛江核电",CompanyId="cddf0dc5-2064-45e8-bfe7-2e8b84f9beae",CompanyTypeId="738212f5-99ca-4c74-802a-247f1ab3454e",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="广西白龙核电",CompanyId="b52bfeca-b00c-4df1-80b9-dc28b768e463",CompanyTypeId="738212f5-99ca-4c74-802a-247f1ab3454e",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="福清核电",CompanyId="c4f4439c-735c-4d72-8dee-4c8932d2e6d5",CompanyTypeId="738212f5-99ca-4c74-802a-247f1ab3454e",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="海狮泵业",CompanyId="839d9ec0-09c0-458b-a349-8ddf7bf22c20",CompanyTypeId="738212f5-99ca-4c74-802a-247f1ab3454e",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="上海交通大学",CompanyId="ce4cd3a1-aedd-4fc2-8ecf-c7ca50c35d57",CompanyTypeId="38a88fd6-028e-435d-9b79-80ff2f469dca",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="上海交通大学/机械与动力工程学院核学院",CompanyId="77a60e16-af04-4d7f-bb33-4c3f84de7687",CompanyTypeId="38a88fd6-028e-435d-9b79-80ff2f469dca",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="西安交通大学/能源与动力工程学院",CompanyId="086837a0-20c5-4c1c-ae29-9d0dfaef3914",CompanyTypeId="38a88fd6-028e-435d-9b79-80ff2f469dca",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="上海大学",CompanyId="677f3b83-0734-4acc-b3a3-25ebe8c4bd5b",CompanyTypeId="38a88fd6-028e-435d-9b79-80ff2f469dca",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="中国水利水电研究院抗震中心",CompanyId="7201cb71-2bd6-4e3e-b695-1c90ed58d00d",CompanyTypeId="38a88fd6-028e-435d-9b79-80ff2f469dca",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="中船718所",CompanyId="5fa8083b-4822-4b93-abf9-28fbd0ce041f",CompanyTypeId="38a88fd6-028e-435d-9b79-80ff2f469dca",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="中核北方核燃料元件有限公司",CompanyId="727523bd-c4e2-4c96-8841-80c569233a45",CompanyTypeId="61e97296-f764-4907-9ac2-a973e9ccb242",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="上海电气核电集团技术中心",CompanyId="787b4fd2-8bbf-435a-98eb-3ef79d5f4c48",CompanyTypeId="61e97296-f764-4907-9ac2-a973e9ccb242",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="上海电气核电集团",CompanyId="fa132c0c-dc8a-40ea-9a9c-f79b6325fe63",CompanyTypeId="61e97296-f764-4907-9ac2-a973e9ccb242",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="大西洋公司（四川）",CompanyId="d47901da-cbf0-46d5-8d1c-ec92744968c4",CompanyTypeId="61e97296-f764-4907-9ac2-a973e9ccb242",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="江苏宝宸",CompanyId="492d969c-1b3f-45a2-86f8-980ec72ad963",CompanyTypeId="61e97296-f764-4907-9ac2-a973e9ccb242",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="常州电站辅机",CompanyId="389b63fc-b88f-43da-9263-700d6594d1d6",CompanyTypeId="61e97296-f764-4907-9ac2-a973e9ccb242",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="江苏希达",CompanyId="45812ebc-b5cb-4d83-bf36-ab55cefc664b",CompanyTypeId="61e97296-f764-4907-9ac2-a973e9ccb242",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="老专家",CompanyId="79e9f768-b0f9-4276-b5d7-8c397333a1d7",CompanyTypeId="39bb10d0-c010-4d46-9777-8e7da96d9d53",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //                new Company(){Name="阿里云",CompanyId="09cf599e-45ab-430d-8c6d-86ba16cc64f6",CompanyTypeId="39bb10d0-c010-4d46-9777-8e7da96d9d53",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //             };

            //            var users = new List<User>()
            //            {
            //               new User(){Name="杜希平",UserId="b0e7b639-1d3c-4431-965c-81120cba55a2",Position="原副司令",CompanyId="d2ff3423-bbc4-4acc-849e-5f6013560d88",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="王泽平",UserId="e596f5d5-f4de-478b-b306-1c87969aa49f",Position="主任",CompanyId="45a35aac-2d4f-476c-aba2-0d09fa4e6d79",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="汪祖蓉",UserId="cbb1496d-560a-49f2-bd04-b4a7aa30ec3d",Position="原主任",CompanyId="682c0429-2876-4bb6-8f98-51ab03118e5f",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="李鹤富",UserId="368e5fce-af51-47bd-9c49-9113f805b65f",Position="原主任",CompanyId="682c0429-2876-4bb6-8f98-51ab03118e5f",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="金玉敏",UserId="82ebf1c5-0434-40f8-8ae5-287086cfec62",Position="副主任",CompanyId="682c0429-2876-4bb6-8f98-51ab03118e5f",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="张宏韬",UserId="185c4ef8-c617-4309-ae99-c4cb6bba0629",Position="副主任",CompanyId="682c0429-2876-4bb6-8f98-51ab03118e5f",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="夏春申",UserId="3e1d308e-5f64-4d34-a04d-aabb707f8de2",Position="专家",CompanyId="682c0429-2876-4bb6-8f98-51ab03118e5f",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="庄伟业",UserId="f86735dc-44d2-45ba-afc7-b8bda629230c",Position="副处长",CompanyId="682c0429-2876-4bb6-8f98-51ab03118e5f",Mobile="18018888037",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="朱军民",UserId="ea771dd9-ffca-4f4c-a225-0c673c64618a",Position="处长",CompanyId="682c0429-2876-4bb6-8f98-51ab03118e5f",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="周凌",UserId="f3c51964-4fc8-4f59-a36e-2298fbc48356",Position="处长",CompanyId="682c0429-2876-4bb6-8f98-51ab03118e5f",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="席斌",UserId="5072a508-c971-4cfa-92d8-633623206856",Position="副处长",CompanyId="682c0429-2876-4bb6-8f98-51ab03118e5f",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="张国华",UserId="3da25d1f-32ca-4247-adc9-061231379636",Position="副处长",CompanyId="459660f2-2ef8-4cb3-888e-6ae6818e4a57",Mobile="18917610800",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="王晶",UserId="2637a0c8-2bc0-4ee6-89fa-9d06a4948b85",Position="处长",CompanyId="263653ac-2d01-4c23-b793-51dcd3a75bbf",Mobile="18018888696",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="王明政",UserId="abf3cad8-28ef-4e58-8a21-32e925750240",Position="堆工部副所长",CompanyId="d7e61816-0067-43ea-b166-d26f601f0f0a",Mobile="13683187261",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="孙志勇",UserId="ad7873f0-4212-4d0c-83fa-2cd88ec2a8f2",Position="堆工部科生办主任",CompanyId="d7e61816-0067-43ea-b166-d26f601f0f0a",Mobile="13910563497",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="孙文科",UserId="03b2e1c1-ecfb-4448-b4ff-adcdea38320c",Position="国家核电总工程师，公司执行董事、党委书记",CompanyId="a231d818-5084-47c1-afd1-e6eb9cfc5768",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="王明弹",UserId="76717e2b-1fb7-49e2-82f3-4f95d21af177",Position="总经理",CompanyId="a231d818-5084-47c1-afd1-e6eb9cfc5768",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="米霖南",UserId="d6ef343f-7ed8-4a00-82ee-478d309511ee",Position="团委书记",CompanyId="a231d818-5084-47c1-afd1-e6eb9cfc5768",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="张明",UserId="92660502-99a0-4002-963f-67433efd104b",Position="主系统工艺经理",CompanyId="a231d818-5084-47c1-afd1-e6eb9cfc5768",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="路丁",UserId="8d15664a-0158-4c46-a009-fa6e79f21feb",Position="",CompanyId="a231d818-5084-47c1-afd1-e6eb9cfc5768",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="张金东",UserId="7f498c6d-0e77-466d-b9ab-118d110763b0",Position="",CompanyId="a231d818-5084-47c1-afd1-e6eb9cfc5768",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="王君栋",UserId="ac2697ad-6ae9-4114-857a-a35a9b4951c1",Position="副总工程师、技术与设计管理部主任",CompanyId="3779e810-ae7d-4856-b8b5-963e8cacdc95",Mobile="18663187602",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="杨堃",UserId="b0c7521a-d509-4d0e-a275-dd3dd2ca5620",Position="设备管理与采购部主任",CompanyId="3779e810-ae7d-4856-b8b5-963e8cacdc95",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="吴兰强",UserId="ea1d35f6-e6ac-4fbc-ad11-a521cb5f7449",Position="党群部主任",CompanyId="3779e810-ae7d-4856-b8b5-963e8cacdc95",Mobile="18663187218",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="薄纯青",UserId="652cf01e-7115-473c-891b-0b95ef8a5988",Position="",CompanyId="3779e810-ae7d-4856-b8b5-963e8cacdc95",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="王伟",UserId="4b65c496-a0ae-48a5-8ce4-366419c14c39",Position="",CompanyId="3779e810-ae7d-4856-b8b5-963e8cacdc95",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="孙云根",UserId="f4446a0a-9288-447f-a361-afb4b64a34e2",Position="副总经理",CompanyId="2ab90b22-fc87-4289-bb63-e1e7a861e986",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="张培来",UserId="b9e08e9b-68f1-435c-9183-931414c8c0e1",Position="设计管理部主任",CompanyId="c2e063dd-8183-4fd3-b0c2-708296ee997d",Mobile="13375769368‬",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="赵云",UserId="a34c68a0-aba4-483f-922b-8f56b7a7ea56",Position="副总经理",CompanyId="8e611af6-2fbf-4336-8669-e0750e01434c",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="王志兵",UserId="ceae7d9b-aae5-4836-8b58-1b078317227b",Position="商务处处长",CompanyId="8e611af6-2fbf-4336-8669-e0750e01434c",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="高宁",UserId="d2e99bb4-82cb-4aae-84ac-de068605e926",Position="设计部主任工程师",CompanyId="a749e1cc-2146-427e-b16e-d2093f2bb0e1",Mobile="18663187602",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="王奇文",UserId="e23be0c3-21cd-47e7-a5f4-875a2ec9f324",Position="总经理",CompanyId="5f8eb33b-220b-4fea-8e85-7c5d0a086e09",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="吴炳泉",UserId="0b175110-1640-4e26-a3b7-183f1104f02c",Position="副总经理  ",CompanyId="5f8eb33b-220b-4fea-8e85-7c5d0a086e09",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="姚启明",UserId="c026ac01-c79b-42c3-97c4-bc2eec02a646",Position="秦山核电三期原总经理",CompanyId="5f8eb33b-220b-4fea-8e85-7c5d0a086e09",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="徐俊栋",UserId="e721b56c-7b68-444f-9a5e-3c8f3800b4df",Position="秦山核电三期原副总经理",CompanyId="5f8eb33b-220b-4fea-8e85-7c5d0a086e09",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="郑永祥",UserId="eda8901b-ff83-4e9d-ab7d-dd71e2755181",Position="副总工程师",CompanyId="5f8eb33b-220b-4fea-8e85-7c5d0a086e09",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="陈梁",UserId="341cb90d-5e3e-4c04-b124-e6f7474db5b0",Position="秦山一厂副厂长、维修一处处长",CompanyId="5f8eb33b-220b-4fea-8e85-7c5d0a086e09",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="陈明军",UserId="c08d2a2e-150f-4a11-a22f-e8cf3a20372f",Position="秦山三厂副厂长、技术三处处长",CompanyId="5f8eb33b-220b-4fea-8e85-7c5d0a086e09",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="张海伦",UserId="6901b87c-6d2e-436e-af24-91d4d791b5c2",Position="公司办公室主任",CompanyId="5f8eb33b-220b-4fea-8e85-7c5d0a086e09",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="伍兴华",UserId="56d3d892-cb3c-44e0-9ce6-405270eaef34",Position="秘书科",CompanyId="5f8eb33b-220b-4fea-8e85-7c5d0a086e09",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="姜赫",UserId="13579b85-18ea-4992-b907-c8098d0cb9c9",Position="技术支持处电厂寿命与退役科科长",CompanyId="5f8eb33b-220b-4fea-8e85-7c5d0a086e09",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="陈坚刚",UserId="99ab14fd-d93a-4ce8-bf98-f8c6c0aeffb1",Position="技术二处变更管理科科长",CompanyId="5f8eb33b-220b-4fea-8e85-7c5d0a086e09",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="章逸民",UserId="7c25a645-07b8-4f73-8ce3-0f5c55021016",Position="副总工程师",CompanyId="4e87c107-80d4-4863-bd8f-7a2147bc7212",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="丁军",UserId="d504ee00-f6f8-420e-9ba1-a39e1cdee1c5",Position="工程管理部主任",CompanyId="cddf0dc5-2064-45e8-bfe7-2e8b84f9beae",Mobile="18022667110",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="黄飞",UserId="09404a5e-b6f2-4c05-8daf-9732ad9b9e92",Position="公司副总经理",CompanyId="b52bfeca-b00c-4df1-80b9-dc28b768e463",Mobile="18607819803",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="张俊胜",UserId="267ef71a-1edb-4376-8efb-369aa78b3ea8",Position="计划合同部总经理",CompanyId="b52bfeca-b00c-4df1-80b9-dc28b768e463",Mobile="13707870179",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="薛峻峰",UserId="0d0b85a8-9f3c-4bdb-b1d5-bf17a5cdca84",Position="副总工程师",CompanyId="c4f4439c-735c-4d72-8dee-4c8932d2e6d5",Mobile="18120806719",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="项达章",UserId="9820b184-87e9-40c2-a8a8-c97664b46de9",Position="董事长",CompanyId="839d9ec0-09c0-458b-a349-8ddf7bf22c20",Mobile="13905261807",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="奚立峰",UserId="2f2bd90d-0976-45fd-b7db-e565c0578f0b",Position="副校长",CompanyId="ce4cd3a1-aedd-4fc2-8ecf-c7ca50c35d57",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="顾汉洋",UserId="9fe20f79-8d9f-4034-bf40-af3e07f499fe",Position="核学院副院长",CompanyId="77a60e16-af04-4d7f-bb33-4c3f84de7687",Mobile="13761175315",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="秋穗正",UserId="4e6b6bd0-91f1-4b57-a376-67757c2daeda",Position="副院长",CompanyId="086837a0-20c5-4c1c-ae29-9d0dfaef3914",Mobile="13152410318",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="刘文光",UserId="205d55ef-f0b5-4dde-b373-2304516587c0",Position="核电站隔震减震工程技术中心 主任",CompanyId="677f3b83-0734-4acc-b3a3-25ebe8c4bd5b",Mobile="13701888336",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="胡晓",UserId="64b570ef-0a7f-464a-b347-ddb16535ed6d",Position="主任",CompanyId="7201cb71-2bd6-4e3e-b695-1c90ed58d00d",Mobile="13601242056",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="宫志刚",UserId="6ed5b8ac-00fc-442b-85ad-4be64de349c1",Position="副所长",CompanyId="5fa8083b-4822-4b93-abf9-28fbd0ce041f",Mobile="15690019721",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="姜韶堃",UserId="0c660ea9-7dc1-4ff7-994d-c5f0da8edfbd",Position="核电事业部副部长",CompanyId="5fa8083b-4822-4b93-abf9-28fbd0ce041f",Mobile="15200115538",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="王翰骏",UserId="a865607f-7d57-4a96-84cd-8a4cb95978c1",Position="高级顾问",CompanyId="727523bd-c4e2-4c96-8841-80c569233a45",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="唐伟宝",UserId="3230ec51-0267-4f57-98ca-5d4577d38e60",Position="总工程师",CompanyId="787b4fd2-8bbf-435a-98eb-3ef79d5f4c48",Mobile="18116023236",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="杨巨文",UserId="9ed365ef-ab9a-4cef-a6eb-55b41c589316",Position="材料工程师",CompanyId="fa132c0c-dc8a-40ea-9a9c-f79b6325fe63",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="蒋勇",UserId="12074b1c-5e9a-4c9e-a5a3-0d3c9a357a22",Position="总工程师",CompanyId="d47901da-cbf0-46d5-8d1c-ec92744968c4",Mobile="13890050067",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="明廷泽",UserId="fc8a80dd-cf44-49fa-ac48-f0719a803a1f",Position="技术中心主任",CompanyId="d47901da-cbf0-46d5-8d1c-ec92744968c4",Mobile="13881439777",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="刘兵",UserId="94d418af-38c9-4fa3-ba22-a058b23fc30b",Position="研发部部长",CompanyId="492d969c-1b3f-45a2-86f8-980ec72ad963",Mobile="13584219450",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="姜迎新",UserId="54c59181-281a-4326-840b-2a8a461680e5",Position="副总经理",CompanyId="389b63fc-b88f-43da-9263-700d6594d1d6",Mobile="13961210850",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="刘亚男",UserId="39774331-ad7c-4902-847f-9af60c9bd5a2",Position="工程师",CompanyId="389b63fc-b88f-43da-9263-700d6594d1d6",Mobile="13584217037",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="黄会荣",UserId="3a373218-18a5-4b1c-8b73-3d0e31f4c2b2",Position="经理",CompanyId="45812ebc-b5cb-4d83-bf36-ab55cefc664b",Mobile="13564960555",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="黄炜",UserId="26d86d62-b877-4be8-b010-d29ff2889163",Position="经理",CompanyId="45812ebc-b5cb-4d83-bf36-ab55cefc664b",Mobile="13376004688",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="耿其瑞",UserId="370dc7a0-b28d-4544-b89b-002c8d72d57c",Position="",CompanyId="79e9f768-b0f9-4276-b5d7-8c397333a1d7",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="沈增耀",UserId="69e18afa-6e40-4eb1-aabf-58b85fdcdd9c",Position="",CompanyId="79e9f768-b0f9-4276-b5d7-8c397333a1d7",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="宋杰",UserId="fffe28ac-bb44-4399-bc5b-9bfb4fd3e46e",Position="副总裁",CompanyId="09cf599e-45ab-430d-8c6d-86ba16cc64f6",Mobile="",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},
            //new User(){Name="杨军",UserId="2db2e362-ba9c-4dab-b24e-98ed03f9dee7",Position="公共科技事业部总经理",CompanyId="09cf599e-45ab-430d-8c6d-86ba16cc64f6",Mobile="18600523456",CreatedAt=DateTime.Now,UpdatedAt=DateTime.Now},

            //            };

            //foreach (var t in companyTypes)
            //{
            //    recordEntities.CompanyType.Add(t);
            //}

            //foreach (var c in companyNames)
            //{
            //    recordEntities.Company.Add(c);
            //}

            //foreach (var u in users)
            //{
            //    recordEntities.User.Add(u);
            //}

            //var meeting = new Meeting();
            //meeting.MeetingId = meetingId;
            //meeting.MeetingName = "20180208双会";
            //meeting.MeetingStartTime = new DateTime(2018, 2, 5);
            //meeting.MeetingEndTime = new DateTime(2018, 2, 5);
            //meeting.CreatedAt = DateTime.Now;
            //meeting.UpdatedAt = DateTime.Now;

            //recordEntities.Meeting.Add(meeting);

            //var users = recordEntities.User;
            //foreach (var u in users)
            //{
            //    var newParticipent = new Participant();
            //    newParticipent.MeetingInfo = "";
            //    newParticipent.Notes = "";
            //    newParticipent.ParticipantId = Guid.NewGuid().ToString();
            //    newParticipent.ArrivalInfo = "";
            //    newParticipent.DepartureInfo = "";
            //    newParticipent.ExpertFee = 0;
            //    newParticipent.TravelFee = 0;
            //    newParticipent.CreatedAt = DateTime.Now;
            //    newParticipent.UpdatedAt = DateTime.Now;
            //    newParticipent.UserId = u.UserId;
            //    recordEntities.Participant.Add(newParticipent);
            //}
            //recordEntities.SaveChanges();

            //            var meetingOne = new List<string>()
            //                        {
            //                           "汪祖蓉",
            //"李鹤富",
            //"金玉敏",
            //"张宏韬",
            //"夏春申",
            //"庄伟业",
            //"王明政",
            //"孙志勇",
            //"米霖南",
            //"张明",
            //"路丁",
            //"张金东",
            //"吴兰强",
            //"薄纯青",
            //"王伟",
            //"孙云根",
            //"张培来",
            //"赵云",
            //"王志兵",
            //"高宁",
            //"王奇文",
            //"吴炳泉",
            //"姚启明",
            //"徐俊栋",
            //"郑永祥",
            //"陈梁",
            //"陈明军",
            //"张海伦",
            //"伍兴华",
            //"姜赫",
            //"陈坚刚",
            //"章逸民",
            //"丁军",
            //"黄飞",
            //"薛峻峰",
            //"顾汉洋",
            //"秋穗正",
            //"刘文光",
            //"胡晓",
            //"宫志刚",
            //"姜韶堃",
            //"王翰骏",
            //"唐伟宝",
            //"杨巨文",
            //"蒋勇",
            //"明廷泽",
            //"刘兵",
            //"姜迎新",
            //"刘亚男",
            //"黄会荣",
            //"黄炜",
            //"耿其瑞",
            //"沈增耀",
            //                        };

            //            foreach (var p in meetingOne)
            //            {
            //                var participant = recordEntities.Participant.FirstOrDefault(pt => pt.User.Name == p);

            //                if (participant != null)
            //                {
            //                    var newEvent = new ParticipantEvent();
            //                    newEvent.ParticipantId = participant.ParticipantId;
            //                    newEvent.MeetingId = "e787dd05-a736-41bb-a5c9-3d6e76b16ac3";
            //                    newEvent.EventId = Guid.NewGuid().ToString();
            //                    newEvent.UpdatedAt = DateTime.Now;
            //                    newEvent.CreatedAt = DateTime.Now;
            //                    recordEntities.ParticipantEvent.Add(newEvent);
            //                }

            //            }

            //            var meetingTwo = new List<string>()
            //                        {
            //                          "杜希平",
            //"王泽平",
            //"张宏韬",
            //"朱军民",
            //"周凌",
            //"席斌",
            //"张国华",
            //"王晶",
            //"王明政",
            //"孙志勇",
            //"孙文科",
            //"王明弹",
            //"王君栋",
            //"杨堃",
            //"孙云根",
            //"张培来",
            //"赵云",
            //"王志兵",
            //"高宁",
            //"王奇文",
            //"吴炳泉",
            //"姚启明",
            //"徐俊栋",
            //"郑永祥",
            //"陈梁",
            //"陈明军",
            //"张海伦",
            //"伍兴华",
            //"章逸民",
            //"丁军",
            //"薛峻峰",
            //"项达章",
            //"奚立峰",
            //"顾汉洋",
            //"秋穗正",
            //"刘文光",
            //"胡晓",
            //"王翰骏",
            //"唐伟宝",
            //"姜迎新",
            //"宋杰",
            //"杨军",

            //                        };

            //            foreach (var p in meetingTwo)
            //            {
            //                var participant = recordEntities.Participant.FirstOrDefault(pt => pt.User.Name == p);

            //                if (participant != null)
            //                {
            //                    var newEvent = new ParticipantEvent();
            //                    newEvent.ParticipantId = participant.ParticipantId;
            //                    newEvent.MeetingId = "c78f8e4d-0564-4e6b-8632-3299d970eeb1";
            //                    newEvent.EventId = Guid.NewGuid().ToString();
            //                    newEvent.UpdatedAt = DateTime.Now;
            //                    newEvent.CreatedAt = DateTime.Now;
            //                    recordEntities.ParticipantEvent.Add(newEvent);
            //                }
            //            }

            var people = new Dictionary<string, string>();
            people.Add("丁军", "7001");
            people.Add("黄飞", "7004");
            people.Add("张俊胜", "7005");
            people.Add("薛峻峰", "7006");
            people.Add("胡晓", "7007");
            people.Add("宫志刚", "7008");
            people.Add("姜韶堃", "7010");
            people.Add("王翰骏", "7011");
            people.Add("蒋勇", "7012");
            people.Add("章逸民", "8001");
            people.Add("杜希平", "8002");
            people.Add("张明", "8003");
            people.Add("王君栋", "8004");
            people.Add("杨堃", "8005");
            people.Add("吴兰强", "8006");
            people.Add("张培来", "8007");
            people.Add("赵云", "8008");
            people.Add("王志兵", "8010");
            people.Add("王明政", "8011");
            people.Add("孙志勇", "8012");
            people.Add("明廷泽", "9001");
            people.Add("高宁", "9003");
            people.Add("宋杰", "9004");
            people.Add("杨军", "9005");

            foreach (var p in recordEntities.Participant)
            {
                if(people.ContainsKey(p.User.Name))
                {
                    p.MeetingInfo = "<hr /><h4>您的住宿信息</h4>" +
                        "<p>上海核工程研究设计院有限公司<br/>科技交流中心<br/>房间号：" + people[p.User.Name] + "</p>" + p.MeetingInfo;
                }
            }

            recordEntities.SaveChanges();

            return View();
        }
    }
}