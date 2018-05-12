var DarenTechs = DarenTechs || {};

DarenTechs.Paragraph = (function () {

    var Paragraph = function () {
        // Private variable
        var strTextVar = "";
        var strSelectedTextVar = "";

        // Public variable
        var startTextPosition = "0";
        var endTextPosition = "0";

        // Private Functions
        function pSetText(strText) {
            strTextVar = strText;
        }

        function pSetSelectedText(strSelectedText) {
            strSelectedTextVar = strSelectedText;
        }

        function pGetText() {
            return strTextVar;
        }

        function pGetSelectedText(strSelectedText) {
            return strSelectedTextVar;
        }

        // Public Funtions 
        function SetText(strText) {
            pSetText(strText); // set private function
        }

        function SetSelectedText(strSelectedText) {
            pSetSelectedText(strSelectedText); // set private function
        }

        function GetText() {
            return pGetText();
        }

        function GetSelectedText() {
            return pGetSelectedText();
        }

        return {
            startPoistion: startTextPosition,
            endPoistion: endTextPosition,
            setText: SetText,
            setSelectedText: SetSelectedText,
            getText: GetText,
            getSelectedText: GetSelectedText
        };

    }
    return Paragraph;
})();

