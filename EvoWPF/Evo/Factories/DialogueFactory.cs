using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evo.GameObjects.Dialogues;
namespace Evo.Factories
{
    public static class DialogueFactory
    {



        public static DialogueNode TestDialauge() 
        {
            DialogueNode init = new DialogueNode();


            DialogueNode dn1 = new DialogueNode();
            dn1.Response = "Observe the person";
            dn1.Words = "A person stands there looking off in the distance";

            DialogueNode dn2 = new DialogueNode();
            dn2.Response = "Poke the person";
            dn2.Words = "\"Oi, you, yeah you. Whose side are you on?\"";

            DialogueNode dn3 = new DialogueNode();
            dn3.Response = "\"Yours of corse!\"";
            dn3.Words = "\"Glad to hear it.\"";

            DialogueNode dn4 = new DialogueNode();
            dn4.Response = "\"Uhhh, idk\"";
            dn4.Words = "\"ok...\"";

            init.AddDialogueNode(dn1);
            dn1.AddDialogueNode(dn2);
            dn2.AddDialogueNode(dn3);
            dn2.AddDialogueNode(dn4);
            return init;
        }


        /*
         * responder is the one choosing the dialogue
         */
        public static DialogueNode GetNextNode(Entity responder, Entity reactor, DialogueNode dialogueNode, int responseNumber) 
        {
            if (dialogueNode.DialogueNodeList.Count > responseNumber)
            {
                responder.addObjectStringEvents("" + responder.getObjectName() + ": " + dialogueNode.DialogueNodeList[responseNumber].Response + "\n");

                responder.addObjectStringEvents("" + reactor.getObjectName() + ": " + dialogueNode.DialogueNodeList[responseNumber].Words);
                DialogueNode selected = dialogueNode.DialogueNodeList[responseNumber];
                return selected;
            }
            else 
            {
                return dialogueNode;
            }

            
        }


    


    }
}
