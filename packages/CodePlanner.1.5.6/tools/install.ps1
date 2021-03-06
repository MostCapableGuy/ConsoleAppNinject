﻿##############################################################################
# Copyright (c) 2013 
# Ulf Tomas Björklund
# http://average-uffe.blogspot.com/
# http://twitter.com/ulfbjo
#
# Permission is hereby granted, free of charge, to any person obtaining
# a copy of this software and associated documentation files (the
# "Software"), to deal in the Software without restriction, including
# without limitation the rights to use, copy, modify, merge, publish,
# distribute, sublicense, and/or sell copies of the Software, and to
# permit persons to whom the Software is furnished to do so, subject to
# the following conditions:
#
# The above copyright notice and this permission notice shall be
# included in all copies or substantial portions of the Software.
#
# THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
# EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
# MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
# NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
# LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
# OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
# WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
##############################################################################
param($installPath, $toolsPath, $package, $project)

$defaultProject = Get-Project
if($defaultProject.Type -ne "C#"){
	Write-Host "Sorry, CodePlanner is only available for C#"
	return
}

Write-Host "You are downloading CodePlanner from Ulf Tomas Bjorklund, the license agreement to which is available at http://codeplanner.codeplex.com/license Check the package for additional dependencies, which may come with their own license agreement(s). Your use of the package and dependencies constitutes your acceptance of their license agreements. If you do not accept the license agreement(s), then delete the relevant components from your device."

$proj = [System.IO.Path]::GetFilename($defaultProject.FullName)
$path = $defaultProject.FullName.Replace($proj,'').Replace('\\','\')


$namespace = (Get-Project).Properties.Item("DefaultNamespace").Value
$rootNamespace = $namespace
$dotIX = $namespace.LastIndexOf('.')
if($dotIX -gt 0){
	$rootNamespace = $namespace.Substring(0,$namespace.LastIndexOf('.'))
}

Scaffold CodePlanner.Architecture
Scaffold CodePlanner.Core.Model
Scaffold CodePlanner.Core.Interfaces
Scaffold CodePlanner.Data
Scaffold CodePlanner.Services


$DTE.ExecuteCommand("Build.BuildSolution")
Start-Sleep -Seconds 2

Write-Host "Check out 'ReadMe.txt' if you are new to CodePlanner"