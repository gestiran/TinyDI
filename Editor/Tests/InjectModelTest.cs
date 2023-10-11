using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using TinyDI.Dependencies;
using TinyDI.Dependencies.Models;

namespace TinyDI.Tests {
    public class InjectModelTest {
        [Test]
        public void InterfaceImplementation_ProjectRuntime() => CheckTypes(Assembly.Load("Project.Boot").GetTypes());

        [Test]
        public void InterfaceImplementation_ProjectControllers() => CheckTypes(Assembly.Load("Project.Controllers").GetTypes());

        [Test]
        public void InterfaceImplementation_ProjectData() => CheckTypes(Assembly.Load("Project.Models").GetTypes());

        [Test]
        public void InterfaceImplementation_ProjectViews() => CheckTypes(Assembly.Load("Project.Views").GetTypes());
        
        private void CheckTypes(Type[] types) {
            for (int typeId = 0; typeId < types.Length; typeId++) {
                if (!types[typeId].IsClass) {
                    continue;
                }

                FieldInfo[] fields = types[typeId].GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                List<FieldInfo> injectFields = GetInjectFields<InjectModel>(fields);
                
                bool isHaveInterface = types[typeId].GetInterfaces().Contains(typeof(IModelsResolving));
                bool isHaveFields = injectFields.Count > 0;

                string message = $"{types[typeId].Name} is have interface {nameof(IModelsResolving)} and not contain {nameof(InjectModel)} fields!";
                Assert.IsFalse(isHaveInterface && !isHaveFields, message);

                message = $"{types[typeId].Name} is have {nameof(InjectModel)} fields {GetNames(injectFields)}and not implement interface {nameof(IModelsResolving)}!";
                Assert.IsFalse(!isHaveInterface && isHaveFields, message);
                
                CheckFields(injectFields);
            }
        }

        private List<FieldInfo> GetInjectFields<T>(FieldInfo[] fields) where T : Inject {
            List<FieldInfo> injectFields = new List<FieldInfo>();
            Type compare = typeof(T);

            for (int fieldId = 0; fieldId < fields.Length; fieldId++) {
                T attribute = (T)Attribute.GetCustomAttribute(fields[fieldId], compare);

                if (attribute == null) {
                    continue;
                }

                injectFields.Add(fields[fieldId]);
            }

            return injectFields;
        }

        private void CheckFields(List<FieldInfo> injectFields) {
            for (int fieldId = 0; fieldId < injectFields.Count; fieldId++) {
                bool isHaveInterface = injectFields[fieldId].FieldType.GetInterfaces().Contains(typeof(IModel));

                string message = $"{injectFields[fieldId].FieldType.Name} is not implement {nameof(IModel)} interface!";
                Assert.IsFalse(!isHaveInterface, message);
            }
        }

        private string GetNames(List<FieldInfo> fields) {
            StringBuilder builder = new StringBuilder(fields.Count);

            for (int fieldId = 0; fieldId < fields.Count; fieldId++) {
                builder.Append($"[{fields[fieldId].FieldType.Name} {fields[fieldId].Name}] ");
            }
            
            return builder.ToString();
        }
    }
}
