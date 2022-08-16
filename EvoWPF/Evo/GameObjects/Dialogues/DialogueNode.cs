using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Evo.GameObjects.Dialogues
{
    [Serializable]
    public class DialogueNode
    {
        //response that leads to this tree
        private string response = "";
        private string words = "";
        private ObservableCollection<DialogueNode> dialogueNodeList = new ObservableCollection<DialogueNode>();
       

        public string Response { get => response; set => response = value; }
        public string Words { get => words; set => words = value; }
        public ObservableCollection<DialogueNode> DialogueNodeList { get => dialogueNodeList; set => dialogueNodeList = value; }
        


        public void AddDialogueNode(DialogueNode dialogueNode) 
        {
            this.dialogueNodeList.Add(dialogueNode);
        }

        public override string ToString()
        {
            return response;
        }

    }
}
