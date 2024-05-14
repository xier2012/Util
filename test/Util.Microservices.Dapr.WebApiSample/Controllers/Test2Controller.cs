using Util.Exceptions;
using Util.Microservices.Dapr.WebApiSample.Dtos;

namespace Util.Microservices.Dapr.WebApiSample.Controllers {
    /// <summary>
    /// ����2������ - ���ڲ���ʹ�÷�����û�ȡδ��װ��ԭʼ����
    /// </summary>
    [ApiController]
    [Route("Test2")]
    public class Test2Controller : ControllerBase {
        /// <summary>
        /// ����Get�������� - �޲��� - �޷���ֵ - �ɹ�
        /// </summary>
        [HttpGet]
        public void Get() {
        }

        /// <summary>
        /// ����Get�������� - �޲��� - �޷���ֵ - ʧ��
        /// </summary>
        [HttpGet( "fail" )]
        public IActionResult Get_Fail() {
            return new BadRequestResult();
        }

        /// <summary>
        /// ����Post�������� - �в��� - �޷���ֵ
        /// </summary>
        [HttpPost]
        public void Post( CustomerDto dto ) {
            if ( dto.Code != "2" )
                throw new Warning( "id����Ϊ2" );
        }

        /// <summary>
        /// ����Get�������� - �޲��� - �з���ֵ
        /// </summary>
        [HttpGet( "customer" )]
        public CustomerDto Get_Customer() {
            var dto = new CustomerDto {
                Name = "ok"
            };
            return dto;
        }

        /// <summary>
        /// ����Get�������� - �в��� - �з���ֵ
        /// </summary>
        [HttpGet( "query" )]
        public CustomerDto Query( [FromQuery] CustomerQuery query ) {
            var dto = new CustomerDto {
                Name = query.Name
            };
            return dto;
        }
    }
}