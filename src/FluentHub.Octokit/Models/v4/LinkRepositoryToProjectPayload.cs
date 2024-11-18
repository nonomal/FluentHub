// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated return type of LinkRepositoryToProject
	/// </summary>
	public class LinkRepositoryToProjectPayload
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The linked Project.
		/// </summary>
		public Project Project { get; set; }

		/// <summary>
		/// The linked Repository.
		/// </summary>
		public Repository Repository { get; set; }
	}
}
