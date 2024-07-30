using FastToHtml.Net.Element.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastToHtml.Net.Script.Common
{
    /// <summary>
    /// Eid支持脚本
    /// </summary>
    public sealed class EidSuportedScript : BaseScript
    {
        /// <summary>
        /// Eid支持脚本
        /// </summary>
        /// <param name="script"></param>
        public EidSuportedScript(ScriptElement script) : base(script)
        {
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <returns></returns>
        protected override string OnRender()
        {
            return @"
                // 定义内联id管理器
                const eids={};
                // 定义内联对象集合
                eids.elements={};
                // 加载对象
                eids.load=function(el){
                    // 遍历所有子元素
                    for(let i=0;i<el.children.length;i++){
                        // 获取子元素
                        const elc=el.children[i];
                        // 加载子元素
                        eids.load(elc);
                        if(!elc.hasAttribute('e-id')){continue;}
                        const elcid=elc.getAttribute('e-id');
                        // 注册元素
                        eids.elements[elcid]=elc;
                    }
                };
                // 初始化绑定
                document.addEventListener('DOMContentLoaded',function(){
                    eids.load(document.body);
                });
            ";
        }
    }
}
