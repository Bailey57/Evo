using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Evo.GameObjects.Dialogue
{
    public class DialogueNode
    {
        private ObservableCollection<DialogueNode> nodeList = new ObservableCollection<DialogueNode>();
        private string words = "";
        

        public DialogueNode(string words)
        {
            this.words = words;
        }

        public string GetWords() 
        {
            return this.words;
        }
        public void SetWords(string words) 
        {
            this.words = words;
        }


        public void AddDialogueNode(DialogueNode dialogueNode) 
        {
            this.nodeList.Add(dialogueNode);
        }




    }
}
