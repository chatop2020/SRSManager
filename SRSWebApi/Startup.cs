using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SrsManageCommon;
using SrsManageCommon.ApisStructs;

namespace SrsWebApi
{
   
    
    /// <summary>
    /// webapi配置启动类
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// webapi配置启动类构造
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 配置类
        /// </summary>
        public IConfiguration Configuration { get; }


        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // 注册Swagger服务
            services.AddSwaggerGen(c =>
            {
                // 添加文档信息
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "SRSWebApi", Version = "v1"});
                //c.IncludeXmlComments(Path.Combine(Program.common.WorkPath, "Edu.Model.xml"));//这里增加model注释，返回值会增加注释：需要Edu.Model项目属性，生成中输出xml文件
                c.IncludeXmlComments(Path.Combine(Program.CommonFunctions.WorkPath, "Edu.Swagger.xml"));
            });
           
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers();
         
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            // 启用Swagger中间件
            app.UseSwagger();

            // 配置SwaggerUI
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "SRSWebApi"); });

            app.UseExceptionHandler(
                options =>
                {
                    options.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            context.Response.ContentType = "application/json";
                            
                            
                            var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
                            if (null != exceptionObject)
                            {
                                ResponseStruct rs = new ResponseStruct()
                                {
                                    Code = ErrorNumber.SystemWebApiException,
                                    Message = ErrorMessage.ErrorDic![ErrorNumber.SystemWebApiException] + "\r\n" +
                                              exceptionObject.Error.Message + "\r\n" + exceptionObject.Error.StackTrace,
                                };
                                var errorMessage = JsonHelper.ToJson(rs);
                                await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
                            }
                        });
                }
            );

            /*app.UseMiddleware(typeof(ExceptionHandlerMiddleWare));*/
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.Use(next => context =>
            {
                context.Request.EnableBuffering();
                return next(context);
            });
        }
    }
}