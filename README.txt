Displays the Tags (taxonomy) applied to the current Module.

1) Install the ZIP package in your DNN site (ContainerTags.zip)

2) Register the tag in your Container.ascx file:

	<%@ Register TagPrefix="dnnspot" TagName="CONTAINERTAGS" Src="~/DesktopModules/DNNspot/Tags/ContainerTags.ascx" %>

3) Include it in your markup somewhwere:

	<dnnspot:CONTAINERTAGS runat="server" />